---
title: Android'de Sunumlarda VBA Projelerini Yönetme
linktitle: VBA ile Sunum
type: docs
weight: 250
url: /tr/androidjava/presentation-via-vba/
keywords:
- makro
- VBA
- VBA makro
- makro ekle
- makro kaldır
- makro çıkart
- VBA ekle
- VBA kaldır
- VBA çıkar
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java kullanarak VBA aracılığıyla PowerPoint ve OpenDocument sunumları oluşturmayı ve manipüle etmeyi keşfedin ve iş akışınızı basitleştirin."
---
## **Giriş**

Aspose.Slides, makrolar ve VBA kodu ile çalışmak için sınıflar ve arabirimler sağlar.

{{% alert title="Note" color="warning" %}} 
Makrolar içeren bir sunumu farklı bir dosya biçimine (PDF, HTML vb.) dönüştürdüğünüzde, Aspose.Slides tüm makroları yoksayar (makrolar elde edilen dosyaya taşınmaz).

Sunuma makro eklediğinizde veya makro içeren bir sunumu yeniden kaydettiğinizde, Aspose.Slides sadece makroların baytlarını yazar.

Aspose.Slides **asla** bir sunumdaki makroları çalıştırmaz.
{{% /alert %}}

## **VBA Makroları Ekleme**

Aspose.Slides, VBA projeleri (ve proje referansları) oluşturmanıza ve mevcut modülleri düzenlemenize olanak tanıyan [VbaProject](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/vbaproject/) sınıfını sağlar. Sunuma gömülü VBA'yı yönetmek için [IVbaProject](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivbaproject/) arabirimini kullanabilirsiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının örneğini oluşturun.
2. Yeni bir VBA projesi eklemek için [VbaProject](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/vbaproject/#VbaProject--) yapıcı metodunu kullanın.
3. VbaProject'e bir modül ekleyin.
4. Modül kaynak kodunu ayarlayın.
5. <stdole> referanslarını ekleyin.
6. **Microsoft Office** referanslarını ekleyin.
7. Referansları VBA projesiyle ilişkilendirin.
8. Sunumu kaydedin.

Bu Java kodu, bir sunuma sıfırdan VBA makrosu eklemenin nasıl yapılacağını gösterir:

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

{{% alert color="info" %}} 
**Aspose** [Macro Remover](https://products.aspose.app/slides/tr/remove-macros) adlı ücretsiz web uygulamasını kontrol etmek isteyebilirsiniz; bu uygulama PowerPoint, Excel ve Word belgelerindeki makroları kaldırmak için kullanılır. 
{{% /alert %}} 

## **VBA Makrolarını Kaldırma**

[Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfı altındaki [VbaProject](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getVbaProject--) özelliğini kullanarak bir VBA makrosunu kaldırabilirsiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının örneğini oluşturun ve makro içeren sunumu yükleyin.
2. Macro modülüne erişin ve onu kaldırın.
3. Değiştirilen sunumu kaydedin.

Bu Java kodu, bir VBA makrosunu nasıl kaldıracağınızı gösterir:

```java
import com.aspose.slides.*;

// Makroyu içeren sunumu yükler
Presentation pres = new Presentation("VBA.pptm");
try {
    // Vba modülüne erişir ve kaldırır 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // Sunumu kaydeder
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

## **VBA Makrolarını Çıkarma**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının örneğini oluşturun ve makro içeren sunumu yükleyin.
2. Sunumun bir VBA Projesi içerip içermediğini kontrol edin.
3. VBA Projesinde bulunan tüm modülleri döngüyle işleyerek makroları görüntüleyin.

Bu Java kodu, makrolar içeren bir sunumdan VBA makrolarını nasıl çıkaracağınızı gösterir:

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

[IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivbaproject/#isPasswordProtected--) metodunu kullanarak bir projenin özelliklerinin şifre korumalı olup olmadığını belirleyebilirsiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının örneğini oluşturun ve makro içeren bir sunumu yükleyin.
2. Sunumun bir [VBA projesi](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/vbaproject/) içerip içermediğini kontrol edin.
3. VBA projesinin şifre korumalı olup olmadığını kontrol ederek özelliklerini görüntüleyin.

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

Makrolar, PPTX VBA'yı desteklemediği için kaldırılır. Makroları korumak istiyorsanız PPTM, PPSM veya POTM formatlarını seçin.

### Aspose.Slides, örneğin verileri yenilemek gibi, bir sunum içindeki makroları çalıştırabilir mi?

Hayır. Kütüphane VBA kodunu asla çalıştırmaz; yürütme yalnızca uygun güvenlik ayarlarına sahip PowerPoint içinde mümkündür.

### VBA koduna bağlı ActiveX denetimleriyle çalışmak destekleniyor mu?

Evet, mevcut [ActiveX denetimlerine](/slides/tr/androidjava/activex/) erişebilir, özelliklerini değiştirebilir ve silebilirsiniz. Bu, makroların ActiveX ile etkileşime girdiği durumlarda faydalıdır.