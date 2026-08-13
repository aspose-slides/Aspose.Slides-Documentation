---
title: .NET でプレゼンテーションの VBA プロジェクトを管理する
linktitle: VBA を使用したプレゼンテーション
type: docs
weight: 250
url: /ja/net/presentation-via-vba/
keywords:
- マクロ
- VBA
- VBA マクロ
- マクロの追加
- マクロの削除
- マクロの抽出
- VBA の追加
- VBA の削除
- VBA の抽出
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して VBA で PowerPoint および OpenDocument プレゼンテーションを生成および操作し、ワークフローを効率化する方法をご紹介します。"
---
## **Introduction**

The [Aspose.Slides.Vba](https://reference.aspose.com/slides/ja/net/aspose.slides.vba/) namespace contains classes and interfaces for working with macros and VBA code.

{{% alert title="Note" color="warning" %}} 

When you convert a presentation containing macros to a different file format (PDF, HTML, etc.), Aspose.Slides ignores all macros (macros are not carried into the resulting file).

When you add macros to a presentation or resave a presentation containing macros, Aspose.Slides simply writes the bytes for the macros.

Aspose.Slides **never** runs the macros in a presentation.

{{% /alert %}}

## **Add VBA Macros**

Aspose.Slides provides the [VbaProject](https://reference.aspose.com/slides/ja/net/aspose.slides.vba/vbaproject/) class to allow you to create VBA projects (and project references) and edit existing modules. You can use the [IVbaProject](https://reference.aspose.com/slides/ja/net/aspose.slides.vba/ivbaproject/) interface to manage VBA embedded in a presentation.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) class.
1. Use the [VbaProject](https://reference.aspose.com/slides/ja/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) constructor to add a new VBA project.
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

// プレゼンテーション クラスのインスタンスを作成します
using (Presentation presentation = new Presentation())
{
    // 新しい VBA プロジェクトを作成します
    presentation.VbaProject = new VbaProject();

    // VBA プロジェクトに空のモジュールを追加します
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");

    // モジュールのソースコードを設定します
    module.SourceCode = @"Sub Test(oShape As Shape) MsgBox ""Test"" End Sub";

    // <stdole> への参照を作成します
    VbaReferenceOleTypeLib stdoleReference =
        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Office への参照を作成します
    VbaReferenceOleTypeLib officeReference =
        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // VBA プロジェクトに参照を追加します
    presentation.VbaProject.References.Add(stdoleReference);
    presentation.VbaProject.References.Add(officeReference);

    // プレゼンテーションを保存します
    presentation.Save("AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

{{% alert color="info" %}} 

You may want to check out **Aspose** [Macro Remover](https://products.aspose.app/slides/ja/remove-macros), which a free web app used to remove macros from PowerPoint, Excel, and Word documents. 

{{% /alert %}} 

## **Remove VBA Macros**
Using the [VbaProject](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/vbaproject/) property under the [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) class, you can remove a VBA macro.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) class and load the presentation containing the macro.
1. Access the Macro module and remove it.
1. Save the modified presentation.

This C# code shows you how to remove a VBA macro:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// マクロを含むプレゼンテーションをロードします
using (Presentation presentation = new Presentation("VBA.pptm"))
{
    // Vba モジュールにアクセスして削除します
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // プレゼンテーションを保存します
    presentation.Save("RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```


## **Extract VBA Macros**
1. Create an instance of the [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) class and load the presentation containing the macro.
2. Check if the presentation contains a VBA Project.
3. Loop through all the modules contained in the VBA Project to view the macros.

This C# code shows you how to extract VBA macros from a presentation containing macros:

```c#
using Aspose.Slides;
using Aspose.Slides.Vba;

    // マクロを含むプレゼンテーションをロードします
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // プレゼンテーションに VBA プロジェクトが含まれているか確認します
	{
		foreach (IVbaModule module in pres.VbaProject.Modules)
		{
			Console.WriteLine(module.Name);
			Console.WriteLine(module.SourceCode);
		}
	}
}
```

## **Check Whether a VBA Project Is Password-Protected**

Using the [IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/ja/net/aspose.slides.vba/ivbaproject/ispasswordprotected/) property, you can determine whether a project’s properties are password-protected.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) class and load a presentation that contains a macro.
2. Check whether the presentation contains a [VBA project](https://reference.aspose.com/slides/ja/net/aspose.slides.vba/vbaproject/).
3. Check whether the VBA project is password-protected to view its properties.

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation("VBA.pptm"))
{
    if (presentation.VbaProject != null) // プレゼンテーションに VBA プロジェクトが含まれているか確認します。
    {
        if (presentation.VbaProject.IsPasswordProtected)
        {
            Console.WriteLine($"The VBA Project '{presentation.VbaProject.Name}' is protected by password to view project properties.");
        }
    }
}
```

## **FAQ**

### What happens to macros if I save the presentation as PPTX?

Macros will be removed because PPTX does not support VBA. To keep macros, choose PPTM, PPSM, or POTM.

### Can Aspose.Slides run macros inside a presentation to, for example, refresh data?

No. The library never executes VBA code; execution is only possible inside PowerPoint with the appropriate security settings.

### Is working with ActiveX controls linked to VBA code supported?

Yes, you can access existing [ActiveX controls](/slides/ja/net/activex/), modify their properties, and remove them. This is useful when macros interact with ActiveX.