---
title: پیوند
type: docs
weight: 130
url: /fa/net/examples/elements/hyperlink/
keywords:
- پیوند
- افزودن پیوند
- دسترسی به پیوند
- حذف پیوند
- به‌روزرسانی پیوند
- مثال کد
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "در Aspose.Slides برای .NET، پیوندها را اضافه و مدیریت کنید: متن، اشکال و تصاویر پیوندی، تعیین هدف‌ها و اعمال برای PPT، PPTX و ODP با مثال‌های C#."
---
این مقاله افزودن، دسترسی، حذف و به‌روزرسانی پیوندها روی اشکال را با استفاده از **Aspose.Slides for .NET** نشان می‌دهد.

## **افزودن پیوند**

یک شکل مستطیل با پیوندی که به یک وب‌سایت خارجی اشاره می‌کند ایجاد کنید.

```csharp
static void AddHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");
}
```

## **دسترسی به پیوند**

اطلاعات پیوند را از بخش متنی یک شکل بخوانید.

```csharp
static void AccessHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    var hyperlink = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick;
}
```

## **حذف پیوند**

پیوند را از متن یک شکل پاک کنید.

```csharp
static void RemoveHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    textPortion.PortionFormat.HyperlinkClick = null;
}
```

## **به‌روزرسانی پیوند**

مقصد یک پیوند موجود را تغییر دهید. برای اصلاح متنی که پیشاپیش شامل پیوند است از `HyperlinkManager` استفاده کنید؛ این کار همانند روش به‌روزرسانی پیوندها در PowerPoint به‌صورت ایمن عمل می‌کند.

```csharp
static void UpdateHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://old.example.com");

    // تغییر یک پیوند در متن موجود باید از طریق
    // HyperlinkManager انجام شود نه تنظیم مستقیم ویژگی.
    // این شبیه‌سازی روش به‌روزرسانی ایمن پیوندها در PowerPoint است.
    textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://new.example.com");
}
```