# Проект Учебной практики

## Краткое описание

Проект Учебной практики — это программное обеспечение, написанное на языке C#, предназначенное для поиска *n* первых простых чисел. Программа предоставляет два подхода: простой перебор и метод Решета Эратосфена. Пользователь вводит целое положительное число, и программа отображает все найденные простые числа в удобном интерфейсе.

## Инструкция по установке

1. Убедитесь, что на компьютере установлена [Visual Studio 2022](https://visualstudio.microsoft.com/).
2. Загрузите исходный код программы на локальный компьютер.
3. Откройте проект в Visual Studio 2022.

## Инструкция по сборке

1. Запустите Visual Studio 2022 и откройте проект.
2. В меню Build выберите Build Solution или используйте комбинацию клавиш Ctrl+Shift+B.
3. Убедитесь, что сборка завершена успешно и ошибок нет.

## Документация

### Основные компоненты программы:

- Windows Form `PrimeNumber`: реализует вычисление простых чисел методом перебора.
- Windows Form `Form1`: выполняет вычисление простых чисел с использованием Решета Эратосфена.
- Windows Form `MainMenu`: служит для выбора подхода к вычислению и запускает соответствующие формы.

### Описание методов:

- checkPerfect(int num): проверяет, является ли заданное число простым.
- Обработчики событий:
  - textBox1_TextChanged: валидация введенного числа.
  - button1_Click и button1_Click_1: начало вычислений.
  - animationTimer_Tick: управление анимацией процесса вычислений.

### Особенности:

- Визуализация процесса поиска простых чисел.
- Анимация с разнообразными фразами для отображения статуса.
- Разделение вычислений на строки для упрощенного просмотра результатов.

## Инструкция по совместной работе (Contributing)

Если вы хотите принять участие в разработке Проекта Учебной практики:

1. Сделайте форк репозитория.
2. Внесите изменения в свой форк.
3. Отправьте Pull Request на рассмотрение.

## Информация об авторских правах и лицензировании

Этот проект распространяется по лицензии MIT. Для получения дополнительной информации ознакомьтесь с файлом LICENSE.

---

Проект разработан для образовательных целей и демонстрирует подходы к вычислению простых чисел с помощью C# и Windows Forms.
