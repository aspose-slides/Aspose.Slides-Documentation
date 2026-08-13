---
title: مدیریت پروژه‌های VBA در ارائه‌ها در .NET
linktitle: ارائه از طریق VBA
type: docs
weight: 250
url: /fa/net/presentation-via-vba/
keywords:
- ماکرو
- VBA
- ماکرو VBA
- افزودن ماکرو
- حذف ماکرو
- استخراج ماکرو
- افزودن VBA
- حذف VBA
- استخراج VBA
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "کشف کنید چگونه می‌توانید ارائه‌های PowerPoint و OpenDocument را از طریق VBA با Aspose.Slides برای .NET تولید و دستکاری کنید تا جریان کار خود را بهینه کنید."
---
## **مقدمه**

The [Aspose.Slides.Vba](https://reference.aspose.com/slides/fa/net/aspose.slides.vba/) namespace contains classes and interfaces for working with macros and VBA code.

{{% alert title="Note" color="warning" %}} 

When you convert a presentation containing macros to a different file format (PDF, HTML, etc.), Aspose.Slides ignores all macros (macros are not carried into the resulting file).

When you add macros to a presentation or resave a presentation containing macros, Aspose.Slides simply writes the bytes for the macros.

Aspose.Slides **never** runs the macros in a presentation.

{{% /alert %}}

## **افزودن ماکروهای VBA**

Aspose.Slides provides the [VbaProject](https://reference.aspose.com/slides/fa/net/aspose.slides.vba/vbaproject/) class to allow you to create VBA projects (and project references) and edit existing modules. You can use the [IVbaProject](https://reference.aspose.com/slides/fa/net/aspose.slides.vba/ivbaproject/) interface to manage VBA embedded in a presentation.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) class.  
1. Use the [VbaProject](https://reference.aspose.com/slides/fa/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) constructor to add a new VBA project.  
1. Add a module to the VbaProject.  
1. Set the module source code.  
1. Add references to <stdole>.  
1. Add references to **Microsoft Office**.  
1. Associate the references with the VBA project.  
1. Save the presentation.

This C# code shows you how to add a VBA macro from scratch to a presentation:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

// یک نمونه از کلاس ارائه را ایجاد می‌کند
using (Presentation presentation = new Presentation())
{
    // یک پروژه VBA جدید ایجاد می‌کند
    presentation.VbaProject = new VbaProject();

    // یک ماژول خالی به پروژه VBA اضافه می‌کند
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");

    // کد منبع ماژول را تنظیم می‌کند
    module.SourceCode = @"Sub Test(oShape As Shape) MsgBox ""Test"" End Sub";

    // یک مرجع برای <stdole> ایجاد می‌کند
    VbaReferenceOleTypeLib stdoleReference =
        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // یک مرجع برای Office ایجاد می‌کند
    VbaReferenceOleTypeLib officeReference =
        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // مرجع‌ها را به پروژه VBA اضافه می‌کند
    presentation.VbaProject.References.Add(stdoleReference);
    presentation.VbaProject.References.Add(officeReference);

    // ارائه را ذخیره می‌کند
    presentation.Save("AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

{{% alert color="info" %}} 

You may want to check out **Aspose** [Macro Remover](https://products.aspose.app/slides/fa/remove-macros), which a free web app used to remove macros from PowerPoint, Excel, and Word documents. 

{{% /alert %}} 

## **حذف ماکروهای VBA**
Using the [VbaProject](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/vbaproject/) property under the [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) class, you can remove a VBA macro.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) class and load the presentation containing the macro.  
1. Access the Macro module and remove it.  
1. Save the modified presentation.

This C# code shows you how to remove a VBA macro:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// ارائه حاوی ماکرو را بارگذاری می‌کند
using (Presentation presentation = new Presentation("VBA.pptm"))
{
    // ماژول Vba را دسترسی می‌یابد و آن را حذف می‌کند
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // ارائه را ذخیره می‌کند
    presentation.Save("RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

## **استخراج ماکروهای VBA**
1. Create an instance of the [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) class and load the presentation containing the macro.  
2. Check if the presentation contains a VBA Project.  
3. Loop through all the modules contained in the VBA Project to view the macros.

This C# code shows you how to extract VBA macros from a presentation containing macros:

```c#
using Aspose.Slides;
using Aspose.Slides.Vba;

    // ارائه‌ای که شامل ماکرو است را بارگذاری می‌کند
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // بررسی می‌کند که آیا ارائه شامل پروژه VBA است
	{
		foreach (IVbaModule module in pres.VbaProject.Modules)
		{
			Console.WriteLine(module.Name);
			Console.WriteLine(module.SourceCode);
		}
	}
}
```

## **بررسی اینکه آیا یک پروژه VBA با رمز عبور محافظت می‌شود یا خیر**

Using the [IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/fa/net/aspose.slides.vba/ivbaproject/ispasswordprotected/) property, you can determine whether a project’s properties are password-protected.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) class and load a presentation that contains a macro.  
2. Check whether the presentation contains a [VBA project](https://reference.aspose.com/slides/fa/net/aspose.slides.vba/vbaproject/).  
3. Check whether the VBA project is password-protected to view its properties.

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation("VBA.pptm"))
{
    if (presentation.VbaProject != null) // بررسی می‌کند که آیا ارائه شامل پروژه VBA است.
    {
        if (presentation.VbaProject.IsPasswordProtected)
        {
            Console.WriteLine($"The VBA Project '{presentation.VbaProject.Name}' is protected by password to view project properties.");
        }
    }
}
```

## **سؤالات متداول**

### چه اتفاقی برای ماکروها می‌افتد اگر ارائه را به صورت PPTX ذخیره کنم؟

ماکروها حذف می‌شوند زیرا PPTX از VBA پشتیبانی نمی‌کند. برای نگهداری ماکروها، PPTM، PPSM یا POTM را انتخاب کنید.

### آیا Aspose.Slides می‌تواند ماکروها را داخل یک ارائه اجرا کند تا برای مثال داده‌ها را تازه‌سازی کند؟

خیر. این کتابخانه هیچ‌گاه کد VBA را اجرا نمی‌کند؛ اجرا فقط در داخل PowerPoint با تنظیمات امنیتی مناسب امکان‌پذیر است.

### آیا کار با کنترل‌های ActiveX مرتبط با کد VBA پشتیبانی می‌شود؟

بله، می‌توانید به کنترل‌های ActiveX موجود دسترسی داشته باشید، ویژگی‌های آنها را تغییر دهید و آنها را حذف کنید. این امر زمانی مفید است که ماکروها با ActiveX تعامل داشته باشند.