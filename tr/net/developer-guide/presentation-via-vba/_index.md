---
title: VBA Projelerini .NET’te Sunumlarda Yönetme
linktitle: VBA ile Sunum
type: docs
weight: 250
url: /tr/net/presentation-via-vba/
keywords:
- makro
- VBA
- VBA makro
- makro ekle
- makro kaldır
- makro çıkar
- VBA ekle
- VBA kaldır
- VBA çıkar
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "VBA ile PowerPoint ve OpenDocument sunumlarını Aspose.Slides for .NET kullanarak oluşturmayı ve manipüle etmeyi keşfedin ve iş akışınızı kolaylaştırın."
---
## **Giriş**

The [Aspose.Slides.Vba](https://reference.aspose.com/slides/tr/net/aspose.slides.vba/) ad alanı, makrolar ve VBA kodlarıyla çalışmak için sınıfları ve arabirimleri içerir.

{{% alert title="Note" color="warning" %}} 

When you convert a presentation containing macros to a different file format (PDF, HTML, etc.), Aspose.Slides ignores all macros (macros are not carried into the resulting file).

When you add macros to a presentation or resave a presentation containing macros, Aspose.Slides simply writes the bytes for the macros.

Aspose.Slides **never** runs the macros in a presentation.

{{% /alert %}}

## **VBA Makroları Ekle**

Aspose.Slides, VBA projeleri (ve proje referansları) oluşturmanıza ve mevcut modülleri düzenlemenize olanak tanıyan [VbaProject](https://reference.aspose.com/slides/tr/net/aspose.slides.vba/vbaproject/) sınıfını sağlar. Sunum içinde gömülü VBA'yı yönetmek için [IVbaProject](https://reference.aspose.com/slides/tr/net/aspose.slides.vba/ivbaproject/) arabirimini kullanabilirsiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. [VbaProject](https://reference.aspose.com/slides/tr/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) yapıcısını kullanarak yeni bir VBA projesi ekleyin.
3. VbaProject'e bir modül ekleyin.
4. Modülün kaynak kodunu ayarlayın.
5. <stdole> başvurularını ekleyin.
6. **Microsoft Office** başvurularını ekleyin.
7. Başvuruları VBA projesi ile ilişkilendirin.
8. Sunumu kaydedin.

```c#
    // Sunum sınıfının bir örneğini oluşturur
using (Presentation presentation = new Presentation())
{
    // Yeni bir VBA Projesi oluşturur
    presentation.VbaProject = new VbaProject();

    // VBA projesine boş bir modül ekler
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");
  
    // Modülün kaynak kodunu ayarlar
    module.SourceCode = @"Sub Test(oShape As Shape) MsgBox ""Test"" End Sub";

    // <stdole> için bir referans oluşturur
    VbaReferenceOleTypeLib stdoleReference =
        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Office için bir referans oluşturur
    VbaReferenceOleTypeLib officeReference =
        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // VBA projesine referansları ekler
    presentation.VbaProject.References.Add(stdoleReference);
    presentation.VbaProject.References.Add(officeReference);

            
    // Sunumu kaydeder
    presentation.Save(dataDir + "AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

{{% alert color="primary" %}} 

Ücretsiz bir web uygulaması olan **Aspose** [Macro Remover](https://products.aspose.app/slides/tr/remove-macros) ile PowerPoint, Excel ve Word belgelerindeki makroları kaldırabilirsiniz. 

{{% /alert %}} 

## **VBA Makrolarını Kaldır**

[Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfı altındaki [VbaProject](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/vbaproject/) özelliğini kullanarak bir VBA makrosunu kaldırabilirsiniz.

1. Makroyu içeren sunumu yükleyerek bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
2. Macro modülüne erişin ve kaldırın.
3. Değiştirilmiş sunumu kaydedin.

```c#
    // Makroyu içeren sunumu yükler
using (Presentation presentation = new Presentation(dataDir + "VBA.pptm"))
{
    // Vba modülüne erişir ve kaldırır 
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // Sunumu kaydeder
    presentation.Save(dataDir + "RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

## **VBA Makrolarını Çıkar**

1. Makroyu içeren sunumu yükleyerek bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
2. Sunumun bir VBA Projesi içerip içermediğini kontrol edin.
3. VBA Projesinde bulunan tüm modülleri döngüyle gezerek makroları görüntüleyin.

```c#
    // Makroyu içeren sunumu yükler
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // Sunumun bir VBA Projesi içerip içermediğini kontrol eder
	{
		foreach (IVbaModule module in pres.VbaProject.Modules)
		{
			Console.WriteLine(module.Name);
			Console.WriteLine(module.SourceCode);
		}
	}
}
```

## **Bir VBA Projesinin Şifre Koruması Olup Olmadığını Kontrol Et**

[IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/tr/net/aspose.slides.vba/ivbaproject/ispasswordprotected/) özelliğini kullanarak bir projenin özelliklerinin şifre korumalı olup olmadığını belirleyebilirsiniz.

1. Makro içeren bir sunumu yükleyerek bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
2. Sunumun bir [VBA projesi](https://reference.aspose.com/slides/tr/net/aspose.slides.vba/vbaproject/) içerip içermediğini kontrol edin.
3. VBA projesinin şifre korumalı olup olmadığını kontrol ederek özelliklerini görüntüleyin.

```cs
using (Presentation presentation = new Presentation("VBA.pptm"))
{
    if (presentation.VbaProject != null) // Sunumun bir VBA projesi içerip içermediğini kontrol eder.
    {
        if (presentation.VbaProject.IsPasswordProtected)
        {
            Console.WriteLine($"The VBA Project '{presentation.VbaProject.Name}' is protected by password to view project properties.");
        }
    }
}
```

## **SSS**

**Sunumu PPTX olarak kaydedersem makrolar ne olur?**

Makrolar PPTX VBA'yı desteklemediği için kaldırılacaktır. Makroları korumak için PPTM, PPSM veya POTM formatını seçin.

**Aspose.Slides bir sunum içinde makroları, örneğin veri yenilemek için çalıştırabilir mi?**

Hayır. Kütüphane asla VBA kodunu çalıştırmaz; yürütme yalnızca uygun güvenlik ayarlarına sahip PowerPoint içinde mümkündür.

**VBA koduna bağlı ActiveX denetimlerini kullanmak destekleniyor mu?**

Evet, mevcut [ActiveX kontrollerine](/slides/tr/net/activex/) erişebilir, özelliklerini değiştirebilir ve kaldırabilirsiniz. Bu, makroların ActiveX ile etkileşime girdiği durumlarda faydalıdır.