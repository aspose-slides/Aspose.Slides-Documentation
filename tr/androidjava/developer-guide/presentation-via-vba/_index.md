---
title: Android'de Sunumlarda VBA Projelerini Yönetme
linktitle: VBA ile Sunum
type: docs
weight: 250
url: /tr/androidjava/presentation-via-vba/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile Java kullanarak VBA aracılığıyla PowerPoint ve OpenDocument sunumlarını oluşturma ve düzenleme yöntemlerini keşfedin ve iş akışınızı kolaylaştırın."
---
## **Giriş**

Aspose.Slides, makrolar ve VBA kodu ile çalışmak için sınıflar ve arabirimler sağlar.

{{% alert title="Not" color="warning" %}} 

Makrolar içeren bir sunumu farklı bir dosya biçimine (PDF, HTML vb.) dönüştürdüğünüzde, Aspose.Slides tüm makroları yok sayar (makrolar sonucunda oluşan dosyaya aktarılmaz).

Bir sunuma makro eklediğinizde veya makrolar içeren bir sunumu yeniden kaydettiğinizde, Aspose.Slides yalnızca makroların baytlarını yazar.

Aspose.Slides **asla** bir sunumdaki makroları çalıştırmaz.

{{% /alert %}}

## **VBA Makroları Ekle**

Aspose.Slides, VBA projeleri (ve proje referansları) oluşturmanıza ve mevcut modülleri düzenlemenize olanak tanıyan [VbaProject](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/vbaproject/) sınıfını sağlar. Sunuma gömülü VBA'yı yönetmek için [IVbaProject](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivbaproject/) arabirimini kullanabilirsiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfı örneği oluşturun.
1. Yeni bir VBA projesi eklemek için [VbaProject](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/vbaproject/#VbaProject--) yapıcı metodunu kullanın.
1. VbaProject'e bir modül ekleyin.
1. Modülün kaynak kodunu ayarlayın.
1. <stdole> referansları ekleyin.
1. **Microsoft Office** referansları ekleyin.
1. Referansları VBA projesiyle ilişkilendirin.
1. Sunumu kaydedin.

Bu Java kodu, bir sunuma sıfırdan VBA makrosu eklemenizi gösterir:

```java
// Sunum sınıfının bir örneğini oluşturur
Presentation pres = new Presentation();
try {
    // Yeni bir VBA Projesi oluşturur
    pres.setVbaProject(new VbaProject());
    
    // VBA projesine boş bir modül ekler
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // Modülün kaynak kodunu ayarlar
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    
    // <stdole> referansı oluşturur
    VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    
    // Office referansı oluşturur
    VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    
    // VBA projesine referansları ekler
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
   
    // Sunumu kaydeder
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

**Aspose** [Macro Remover](https://products.aspose.app/slides/tr/remove-macros) adlı ücretsiz web uygulamasını incelemek isteyebilirsiniz; bu uygulama PowerPoint, Excel ve Word belgelerindeki makroları kaldırmak için kullanılır. 

{{% /alert %}} 

## **VBA Makrolarını Kaldır**

[Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının altındaki [VbaProject](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getVbaProject--) özelliğini kullanarak bir VBA makrosunu kaldırabilirsiniz.

1. Makroyu içeren sunumu yükleyerek bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfı örneği oluşturun.
1. Macro modülüne erişin ve onu kaldırın.
1. Değiştirilmiş sunumu kaydedin.

```java
// Makroyu içeren sunumu yükler
Presentation pres = new Presentation("VBA.pptm");
try {
    // Vba modülüne erişir ve onu kaldırır 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // Sunumu kaydeder
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

## **VBA Makrolarını Çıkar**

1. Makroyu içeren sunumu yükleyerek bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfı örneği oluşturun.
2. Sunumun bir VBA Projesi içerip içermediğini kontrol edin.
3. VBA Projesinde bulunan tüm modülleri döngüyle gezerek makroları görüntüleyin.

Bu Java kodu, makrolar içeren bir sunumdan VBA makrolarını nasıl çıkaracağınızı gösterir:

```java
// Makroyu içeren sunumu yükler
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // Sunumun bir VBA Projesi içerip içermediğini kontrol eder
    {
        for (IVbaModule module : pres.getVbaProject().getModules())
        {
            System.out.println(module.getName());
            System.out.println(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bir VBA Projesinin Şifre Koruması Olup Olmadığını Kontrol Et**

[IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivbaproject/#isPasswordProtected--) metodunu kullanarak bir projenin özelliklerinin şifre korumalı olup olmadığını belirleyebilirsiniz.

1. Makro içeren bir sunumu yükleyerek bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfı örneği oluşturun.
2. Sunumun bir [VBA projesi](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/vbaproject/) içerip içermediğini kontrol edin.
3. VBA projesinin şifre korumalı olup olmadığını kontrol ederek özelliklerini görüntüleyin.

```java
Presentation presentation = new Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // Sunumun bir VBA projesi içerip içermediğini kontrol eder.
        if (presentation.getVbaProject().isPasswordProtected()) {
            System.out.printf("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```

## **SSS**

**Sunumu PPTX olarak kaydedersem makrolar ne olur?**

Makrolar PPTX VBA'yı desteklemediği için kaldırılacaktır. Makroları tutmak için PPTM, PPSM veya POTM formatını seçin.

**Aspose.Slides, örneğin verileri yenilemek gibi, bir sunum içindeki makroları çalıştırabilir mi?**

Hayır. Kütüphane VBA kodunu asla çalıştırmaz; yürütme yalnızca uygun güvenlik ayarlarına sahip PowerPoint içinde mümkündür.

**VBA koduna bağlı ActiveX kontrolleriyle çalışmak destekleniyor mu?**

Evet, mevcut [ActiveX kontrollerine](/slides/tr/androidjava/activex/) erişebilir, özelliklerini değiştirebilir ve kaldırabilirsiniz. Bu, makrolar ActiveX ile etkileşime girdiğinde işe yarar.