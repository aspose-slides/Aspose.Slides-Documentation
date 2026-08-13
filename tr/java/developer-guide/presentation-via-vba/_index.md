---
title: Java Kullanarak Sunumlarda VBA Projelerini Yönetme
linktitle: VBA ile Sunum
type: docs
weight: 250
url: /tr/java/presentation-via-vba/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile VBA kullanarak PowerPoint ve OpenDocument sunumlarını oluşturma ve düzenleme yollarını keşfedin ve iş akışınızı hızlandırın."
---
## **Giriş**

Aspose.Slides, makrolar ve VBA kodu ile çalışmak için sınıflar ve arabirimler sağlar.

{{% alert title="Not" color="warning" %}} 

Makrolar içeren bir sunumu farklı bir dosya biçimine (PDF, HTML, vb.) dönüştürdüğünüzde, Aspose.Slides tüm makroları yok sayar (makrolar sonuç dosyasına taşınmaz).

Sunuma makro eklediğinizde veya makrolar içeren bir sunumu yeniden kaydettiğinizde, Aspose.Slides yalnızca makroların baytlarını yazar.

Aspose.Slides **asla** bir sunumdaki makroları çalıştırmaz.

{{% /alert %}}

## **VBA Makroları Ekleme**

Aspose.Slides, VBA projeleri (ve proje referansları) oluşturmanıza ve mevcut modülleri düzenlemenize olanak tanıyan [VbaProject](https://reference.aspose.com/slides/tr/java/com.aspose.slides/vbaproject/) sınıfını sağlar. Sunuma gömülü VBA’yı yönetmek için [IVbaProject](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ivbaproject/) arabirimini kullanabilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. Yeni bir VBA projesi eklemek için [VbaProject](https://reference.aspose.com/slides/tr/java/com.aspose.slides/vbaproject/#VbaProject--) yapıcısını kullanın.
1. VbaProject’e bir modül ekleyin.
1. Modül kaynak kodunu ayarlayın.
1. <stdole> referanslarını ekleyin.
1. **Microsoft Office** referanslarını ekleyin.
1. Referansları VBA projesiyle ilişkilendirin.
1. Sunumu kaydedin.

Bu Java kodu, bir sunuma sıfırdan VBA makrosu eklemenin yolunu gösterir:

```java
import com.aspose.slides.*;

// Sunum sınıfının bir örneğini oluşturur
Presentation pres = new Presentation();
try {
    // Yeni bir VBA Projesi oluşturur
    pres.setVbaProject(new VbaProject());
    
    // VBA projesine boş bir modül ekler
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // Modül kaynak kodunu ayarlar
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    
    // <stdole> için bir referans oluşturur
    VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    
    // Office için bir referans oluşturur
    VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    
    // VBA projesine referanslar ekler
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
   
    // Sunumu kaydeder
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 

Ücretsiz bir web uygulaması olan **Aspose** [Macro Remover](https://products.aspose.app/slides/tr/remove-macros) ile PowerPoint, Excel ve Word belgelerindeki makroları kaldırabilirsiniz. 

{{% /alert %}} 

## **VBA Makrolarını Kaldırma**

[Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının altındaki [VbaProject](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getVbaProject--) özelliğini kullanarak bir VBA makrosunu kaldırabilirsiniz.

1. Makroyu içeren sunumu yüklemek için [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. Makro modülüne erişin ve kaldırın.
1. Değiştirilmiş sunumu kaydedin.

Bu Java kodu, bir VBA makrosunu kaldırmanın yolunu gösterir:

```java
import com.aspose.slides.*;

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

## **VBA Makrolarını Çıkarma**

1. Makroyu içeren sunumu yüklemek için [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
2. Sunumun bir VBA Projesi içerip içermediğini kontrol edin.
3. VBA Projesinde bulunan tüm modülleri dolaşarak makroları görüntüleyin.

Bu Java kodu, makrolar içeren bir sunumdan VBA makrolarını çıkarmanın yolunu gösterir:

```java
import com.aspose.slides.*;

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

1. Makro içeren bir sunumu yüklemek için [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Sunumun bir [VBA projesi](https://reference.aspose.com/slides/tr/java/com.aspose.slides/vbaproject/) içerip içermediğini kontrol edin.
3. VBA projesinin şifre korumalı olup olmadığını kontrol ederek özelliklerini inceleyin.

```java
import com.aspose.slides.*;

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

### Sunumu PPTX olarak kaydedersem makrolar ne olur?

Makrolar kaldırılır çünkü PPTX VBA’yı desteklemez. Makroları tutmak için PPTM, PPSM veya POTM formatlarını seçin.

### Aspose.Slides, örneğin verileri yenilemek gibi bir amaçla sunum içindeki makroları çalıştırabilir mi?

Hayır. Kütüphane VBA kodunu asla çalıştırmaz; yürütme yalnızca PowerPoint içinde, uygun güvenlik ayarlarıyla mümkündür.

### VBA koduna bağlı ActiveX denetimleriyle çalışma destekleniyor mu?

Evet, mevcut [ActiveX controls](/slides/tr/java/activex/) öğelerine erişebilir, özelliklerini değiştirebilir ve kaldırabilirsiniz. Bu, makroların ActiveX ile etkileşimde bulunduğu durumlarda faydalıdır.