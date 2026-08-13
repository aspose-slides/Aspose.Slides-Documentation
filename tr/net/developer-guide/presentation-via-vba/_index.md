---
title: Sunumlarda VBA Projelerini .NET'te Yönetme
linktitle: VBA ile Sunum
type: docs
weight: 250
url: /tr/net/presentation-via-vba/
keywords:
- makro
- VBA
- VBA makrosu
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
description: "Aspose.Slides for .NET ile VBA kullanarak PowerPoint ve OpenDocument sunumlarını oluşturma ve düzenleme yöntemlerini keşfedin, iş akışınızı hızlandırın."
---
## **Giriş**

Aspose.Slides.Vba ad alanı, makrolar ve VBA kodlarıyla çalışmak için sınıflar ve arabirimler içerir.

{{% alert title="Note" color="warning" %}} 

Makrolar içeren bir sunumu farklı bir dosya biçimine (PDF, HTML vb.) dönüştürdüğünüzde, Aspose.Slides tüm makroları yok sayar (makrolar oluşan dosyaya taşınmaz).

Sunuma makro eklediğinizde veya makro içeren bir sunumu yeniden kaydettiğinizde, Aspose.Slides makroların baytlarını sadece yazar.

Aspose.Slides **asla** bir sunumdaki makroları çalıştırmaz.

{{% /alert %}}

## **VBA Makroları Ekle**

Aspose.Slides, VBA projeleri (ve proje başvuruları) oluşturmanıza ve mevcut modülleri düzenlemenize olanak tanıyan [VbaProject](https://reference.aspose.com/slides/tr/net/aspose.slides.vba/vbaproject/) sınıfını sağlar. Sunuma gömülü VBA’yı yönetmek için [IVbaProject](https://reference.aspose.com/slides/tr/net/aspose.slides.vba/ivbaproject/) arabirimini kullanabilirsiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. Yeni bir VBA projesi eklemek için [VbaProject](https://reference.aspose.com/slides/tr/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) yapıcı metodunu kullanın.  
1. VbaProject’e bir modül ekleyin.  
1. Modül kaynak kodunu ayarlayın.  
1. Referansları <stdole> ekleyin.  
1. Referansları **Microsoft Office** ekleyin.  
1. Referansları VBA projesiyle ilişkilendirin.  
1. Sunumu kaydedin.  

Bu C# kodu, bir sunuma sıfırdan VBA makrosu eklemenizi gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

// Sunum sınıfının bir örneğini oluşturur
using (Presentation presentation = new Presentation())
{
    // Yeni bir VBA Projesi oluşturur
    presentation.VbaProject = new VbaProject();

    // VBA projesine boş bir modül ekler
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");

    // Modül kaynak kodunu ayarlar
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
    presentation.Save("AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

{{% alert color="info" %}} 

**Aspose** [Macro Remover](https://products.aspose.app/slides/tr/remove-macros) ücretsiz bir web uygulamasıdır ve PowerPoint, Excel ve Word belgelerinden makroları kaldırmak için kullanılabilir. 

{{% /alert %}} 

## **VBA Makrolarını Kaldır**

[Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının altındaki [VbaProject](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/vbaproject/) özelliğini kullanarak bir VBA makrosunu kaldırabilirsiniz.

1. Makro içeren bir sunumu yükleyerek [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. Macro modülüne erişin ve onu kaldırın.  
1. Değiştirilmiş sunumu kaydedin.  

Bu C# kodu, bir VBA makrosunu nasıl kaldıracağınızı gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Makroyu içeren sunumu yükler
using (Presentation presentation = new Presentation("VBA.pptm"))
{
    // Vba modülüne erişir ve kaldırır
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // Sunumu kaydeder
    presentation.Save("RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

## **VBA Makrolarını Çıkar**

1. Makro içeren bir sunumu yükleyerek [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. Sunumun bir VBA Projesi içerip içermediğini kontrol edin.  
1. VBA Projesinde bulunan tüm modülleri döngüyle gezerek makroları görüntüleyin.  

Bu C# kodu, makrolar içeren bir sunumdan VBA makrolarını nasıl çıkaracağınızı gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Vba;

    // Makroyu içeren sunumu yükler
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // Sunumun VBA Projesi içerip içermediğini kontrol eder
	{
		foreach (IVbaModule module in pres.VbaProject.Modules)
		{
			Console.WriteLine(module.Name);
			Console.WriteLine(module.SourceCode);
		}
	}
}
```

## **Bir VBA Projesinin Parola Koruması Olup Olmadığını Kontrol Et**

[IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/tr/net/aspose.slides.vba/ivbaproject/ispasswordprotected/) özelliğini kullanarak bir projenin özelliklerinin parola korumalı olup olmadığını belirleyebilirsiniz.

1. Makro içeren bir sunumu yükleyerek [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Sunumun bir [VBA projesi](https://reference.aspose.com/slides/tr/net/aspose.slides.vba/vbaproject/) içerip içermediğini kontrol edin.  
3. VBA projesinin özelliklerini görüntülemek için projenin parola korumalı olup olmadığını kontrol edin.  

```cs
using Aspose.Slides;

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

### Sunumu PPTX olarak kaydedersem makrolar ne olur?

Makrolar PPTX VBA’yı desteklemediği için kaldırılacaktır. Makroları korumak için PPTM, PPSM veya POTM formatını seçin.

### Aspose.Slides bir sunum içinde makroları çalıştırabilir mi, örneğin verileri yenilemek gibi?

Hayır. Kütüphane VBA kodunu asla çalıştırmaz; yürütme yalnızca uygun güvenlik ayarlarına sahip PowerPoint içinde mümkündür.

### VBA koduna bağlı ActiveX denetimleriyle çalışmak destekleniyor mu?

Evet, mevcut [ActiveX controls](/slides/tr/net/activex/) erişebilir, özelliklerini değiştirebilir ve kaldırabilirsiniz. Bu, makroların ActiveX ile etkileşime girdiği durumlarda faydalıdır.