---
title: Подстановка шрифтов - PowerPoint C# API
linktitle: Подстановка шрифтов
type: docs
weight: 70
url: /ru/net/font-substitution/
keywords:
- шрифт
- замена шрифта
- PowerPoint
- презентация
- C#
- Csharp
- Aspose.Slides for .NET
description: API PowerPoint на C# позволяет заменять шрифты в презентациях
---

## **Получение замены шрифтов**

Чтобы вы могли узнать, какие шрифты презентации заменяются во время процесса рендеринга презентации, Aspose.Slides предоставляет метод [GetSubstitution](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/) из интерфейса [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/).

C# код показывает, как получить все подстановки шрифтов, выполняемые при рендеринге презентации:
```c#
using (Presentation pres = new Presentation(@"Presentation.pptx"))
{
    foreach (var fontSubstitution in pres.FontsManager.GetSubstitutions())
    {
        Console.WriteLine("{0} -> {1}", fontSubstitution.OriginalFontName, fontSubstitution.SubstitutedFontName);
    }
}
```


## **Настройка правил замены шрифтов**

Aspose.Slides позволяет задать правила для шрифтов, определяющие, что следует делать в определённых условиях (например, когда шрифт недоступен), следующим образом:

1. Загрузите соответствующую презентацию.
2. Загрузите шрифт, который будет заменён.
3. Загрузите новый шрифт.
4. Добавьте правило для замены.
5. Добавьте правило в коллекцию правил замены шрифтов презентации.
6. Сгенерируйте изображение слайда, чтобы увидеть результат.

Этот C# код демонстрирует процесс подстановки шрифтов:
```c#
// Загружает презентацию
Presentation presentation = new Presentation("Fonts.pptx");

// Загружает исходный шрифт, который будет заменён
IFontData sourceFont = new FontData("SomeRareFont");

// Загружает новый шрифт
IFontData destFont = new FontData("Arial");

// Добавляет правило замены шрифта
IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

// Добавляет правило в коллекцию правил замены шрифтов
IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
fontSubstRuleCollection.Add(fontSubstRule);

// Добавляет коллекцию правил в список правил
presentation.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

using (IImage image = presentation.Slides[0].GetImage(1f, 1f))
{
    // Сохраняет изображение на диск в формате JPEG
    image.Save("Thumbnail_out.jpg", ImageFormat.Jpeg);
}
```


{{%  alert title="NOTE"  color="warning"   %}} 
Возможно, вам будет интересен [**Замена шрифтов**](/slides/ru/net/font-replacement/). 
{{% /alert %}}

## **FAQ**

**В чём разница между заменой шрифтов и их подстановкой?**

[Replacement](/slides/ru/net/font-replacement/) — это принудительная замена одного шрифта другим во всей презентации. Подстановка — это правило, которое срабатывает при определённом условии, например когда оригинальный шрифт недоступен, и тогда используется назначенный резервный шрифт.

**Когда именно применяются правила подстановки?**

Правила участвуют в стандартной последовательности [font selection](/slides/ru/net/font-selection-sequence/), которая оценивается во время загрузки, рендеринга и конвертации; если выбранный шрифт недоступен, применяется замена или подстановка.

**Каково поведение по умолчанию, если ни замена, ни подстановка не настроены и шрифт отсутствует в системе?**

Библиотека попытается подобрать ближайший доступный системный шрифт, аналогично тому, как это делает PowerPoint.

**Могу ли я добавить пользовательские внешние шрифты во время выполнения, чтобы избежать подстановки?**

Да. Вы можете [add external fonts](/slides/ru/net/custom-font/) во время выполнения, чтобы библиотека учитывала их при выборе и рендеринге, в том числе при последующих конверсиях.

**Поставляет ли Aspose какие-либо шрифты вместе с библиотекой?**

Нет. Aspose не распространяет платные или бесплатные шрифты; вы добавляете и используете шрифты по своей собственной усмотрению и ответственности.

**Есть ли различия в поведении подстановки на Windows, Linux и macOS?**

Да. Поиск шрифтов начинается с каталогов шрифтов операционной системы. Набор доступных шрифтов по умолчанию и пути поиска различаются между платформами, что влияет на их доступность и необходимость подстановки.

**Как подготовить окружение, чтобы минимизировать неожиданную подстановку при пакетных конверсиях?**

Синхронизируйте набор шрифтов между машинами или контейнерами, [add the external fonts](/slides/ru/net/custom-font/) необходимые для выходных документов, и [embed fonts](/slides/ru/net/embedded-font/) в презентациях, когда это возможно, чтобы выбранные шрифты были доступны во время рендеринга.