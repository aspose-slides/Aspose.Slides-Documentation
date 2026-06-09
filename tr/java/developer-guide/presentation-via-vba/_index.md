---
title: Java ile Sunularda VBA Projelerini Yönetme
linktitle: VBA ile Sunum
type: docs
weight: 250
url: /tr/java/presentation-via-vba/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile VBA kullanarak PowerPoint ve OpenDocument sunumları oluşturmayı ve manipüle etmeyi keşfedin, iş akışınızı kolaylaştırın."
---
## **Giriş**

Aspose.Slides, makrolar ve VBA kodlarıyla çalışmak için sınıflar ve arabirimler sağlar.

{{% alert title="Note" color="warning" %}} 

Bir sunumu makrolar içeriyorken farklı bir dosya biçimine (PDF, HTML, vb.) dönüştürdüğünüzde, Aspose.Slides tüm makroları yok sayar (makrolar sonuç dosyasına aktarılmaz).

Bir sunuma makro eklediğinizde veya makro içeren bir sunuyu yeniden kaydettiğinizde, Aspose.Slides sadece makroların baytlarını yazar.

Aspose.Slides **asla** bir sunumdaki makroları çalıştırmaz.

{{% /alert %}}

## **VBA Makroları Ekleme**

Aspose.Slides, VBA projeleri (ve proje referansları) oluşturmanıza ve mevcut modülleri düzenlemenize olanak tanıyan [VbaProject](https://reference.aspose.com/slides/tr/java/com.aspose.slides/vbaproject/) sınıfını sağlar. Sunuya gömülü VBA’yı yönetmek için [IVbaProject](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ivbaproject/) arabirimini kullanabilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. Yeni bir VBA projesi eklemek için [VbaProject](https://reference.aspose.com/slides/tr/java/com.aspose.slides/vbaproject/#VbaProject--) yapıcı metodunu kullanın.
1. VbaProject’e bir modül ekleyin.
1. Modül kaynak kodunu ayarlayın.
1. <stdole> referanslarını ekleyin.
1. **Microsoft Office** referanslarını ekleyin.
1. Referansları VBA projesiyle ilişkilendirin.
1. Sunumu kaydedin.

Bu Java kodu, baştan bir VBA makrosu eklemenizi gösterir:

```java
// Sunum sınıfının bir örneğini oluşturur
Presentation pres = new Presentation();
try {
    // Yeni bir VBA Projesi oluşturur
    pres.setVbaProject(new VbaProject());
    
    // VBA projesine boş bir modül ekler
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // Modül kaynak kodunu ayarlar
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

**Aspose** [Macro Remover](https://products.aspose.app/slides/tr/remove-macros) adlı, PowerPoint, Excel ve Word belgelerindeki makroları kaldırmak için kullanılan ücretsiz bir web uygulamasına göz atabilirsiniz. 

{{% /alert %}} 

## **VBA Makroları Kaldırma**

[Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının altındaki [VbaProject](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getVbaProject--) özelliğini kullanarak bir VBA makrosunu kaldırabilirsiniz.

1. Makro içeren sunumu yükleyerek bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) örneği oluşturun.
1. Makro modülüne erişin ve onu kaldırın.
1. Değiştirilen sunumu kaydedin.

Bu Java kodu, bir VBA makrosunu nasıl kaldıracağınızı gösterir:

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

## **VBA Makroları Çıkarma**

1. Makro içeren sunumu yükleyerek bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) örneği oluşturun.
2. Sunumun bir VBA Projesi içerip içermediğini kontrol edin.
3. VBA Projesi içinde bulunan tüm modülleri döngüye alarak makroları görüntüleyin.

Bu Java kodu, makro içeren bir sunumdan VBA makrolarını nasıl çıkaracağınızı gösterir:

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

## **Bir VBA Projesinin Şifre Koruması Olup Olmadığını Kontrol Etme**

[IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ivbaproject/#isPasswordProtected--) metodunu kullanarak bir projenin özelliklerinin şifre korumalı olup olmadığını belirleyebilirsiniz.

1. Makro içeren bir sunumu yükleyerek bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) örneği oluşturun.
2. Sunumun bir [VBA projesi](https://reference.aspose.com/slides/tr/java/com.aspose.slides/vbaproject/) içerip içermediğini kontrol edin.
3. VBA projesinin özelliklerini görüntülemek için şifre korumalı olup olmadığını kontrol edin.

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

Makrolar kaldırılır çünkü PPTX VBA’yı desteklemez. Makroları korumak için PPTM, PPSM veya POTM formatlarını seçin.

**Aspose.Slides bir sunumdaki makroları, örneğin veri yenilemek için çalıştırabilir mi?**

Hayır. Kütüphane asla VBA kodunu çalıştırmaz; yürütme yalnızca PowerPoint içinde uygun güvenlik ayarlarıyla mümkündür.

**VBA koduna bağlı ActiveX denetimleriyle çalışmak destekleniyor mu?**

Evet, mevcut [ActiveX controls](/slides/tr/java/activex/) üzerinde erişim sağlayabilir, özelliklerini değiştirebilir ve kaldırabilirsiniz. Bu, makroların ActiveX ile etkileşime girdiği durumlar için faydalıdır.