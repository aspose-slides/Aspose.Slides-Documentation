---
title: JavaScript ile Sunumlarda VBA Projelerini Yönetme
linktitle: VBA ile Sunum
type: docs
weight: 250
url: /tr/nodejs-java/presentation-via-vba/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript'te Aspose.Slides for Node.js aracılığıyla VBA kullanarak PowerPoint ve OpenDocument sunumlarını oluşturun ve yönetin, iş akışınızı hızlandırın."
---
## **Giriş**

Aspose.Slides, makrolar ve VBA kodlarıyla çalışmak için sınıflar sağlar.

{{% alert title="Not" color="warning" %}} 

Bir sunumu makrolar içeriyorken farklı bir dosya biçimine (PDF, HTML vb.) dönüştürdüğünüzde, Aspose.Slides tüm makroları yok sayar (makrolar sonuç dosyasına taşınmaz).

Bir sunuma makro eklediğinizde veya makrolar içeren bir sunuyu yeniden kaydettiğinizde, Aspose.Slides yalnızca makroların baytlarını yazar.

Aspose.Slides **asla** bir sunumdaki makroları çalıştırmaz.

{{% /alert %}}

## **VBA Makroları Ekle**

Aspose.Slides, VBA projeleri (ve proje referansları) oluşturmanıza ve mevcut modülleri düzenlemenize olanak tanıyan [VbaProject](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/vbaproject/) sınıfını sağlar. Sunuma gömülü VBA’yı yönetmek için [VbaProject](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/vbaproject/) sınıfını kullanabilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. Yeni bir VBA projesi eklemek için [VbaProject](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/vbaproject/#VbaProject--) yapılandırıcısını kullanın.
1. VbaProject’e bir modül ekleyin.
1. Modülün kaynak kodunu ayarlayın.
1. <stdole> referansları ekleyin.
1. **Microsoft Office** referansları ekleyin.
1. Referansları VBA projesiyle ilişkilendirin.
1. Sunumu kaydedin.

Bu JavaScript kodu, bir sunuma sıfırdan VBA makrosu eklemenizi gösterir:

```javascript
// Sunum sınıfının bir örneğini oluşturur
let pres = new aspose.slides.Presentation();
try {
    // Yeni bir VBA Projesi oluşturur
    pres.setVbaProject(new aspose.slides.VbaProject());
    // VBA projesine boş bir modül ekler
    let module = pres.getVbaProject().getModules().addEmptyModule("Module");
    // Modülün kaynak kodunu ayarlar
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    // <stdole> için bir referans oluşturur
    let stdoleReference = new aspose.slides.VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    // Office için bir referans oluşturur
    let officeReference = new aspose.slides.VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    // VBA projesine referanslar ekler
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
    // Sunumu kaydeder
    pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 

Ücretsiz bir web uygulaması olan **Aspose** [Macro Remover](https://products.aspose.app/slides/tr/remove-macros) aracını inceleyebilirsiniz; bu araç PowerPoint, Excel ve Word belgelerindeki makroları kaldırmak için kullanılır. 

{{% /alert %}} 

## **VBA Makroları Kaldır**

[Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfının altındaki [VbaProject](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#getVbaProject--) özelliğini kullanarak bir VBA makrosunu kaldırabilirsiniz.

1. Makro içeren sunumu yüklemek için [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. Makro modülüne erişin ve onu kaldırın.
1. Değiştirilen sunumu kaydedin.

Bu JavaScript kodu, bir VBA makrosunu nasıl kaldıracağınızı gösterir:

```javascript
// Makroyu içeren sunumu yükler
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // Vba modülüne erişir ve kaldırır
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    // Sunumu kaydeder
    pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **VBA Makroları Çıkar**

1. Makro içeren sunumu yüklemek için [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
2. Sunumun bir VBA Projesi içerip içermediğini kontrol edin.
3. VBA Projesinde bulunan tüm modülleri döngüye alarak makroları görüntüleyin.

Bu JavaScript kodu, makrolar içeren bir sunumdan VBA makrolarını nasıl çıkaracağınızı gösterir:

```javascript
// Makroyu içeren sunumu yükler
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // Sunumun bir VBA Projesi içerip içermediğini kontrol eder
    if (pres.getVbaProject() != null) {
        for (let i = 0; i < pres.getVbaProject().getModules().size(); i++) {
            let module = pres.getVbaProject().getModules().get_Item(i);
            console.log(module.getName());
            console.log(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Bir VBA Projesinin Parola Koruması Olup Olmadığını Kontrol Et**

[VbaProject.isPasswordProtected](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/vbaproject/#isPasswordProtected) metodunu kullanarak bir projenin özelliklerinin parola korumalı olup olmadığını belirleyebilirsiniz.

1. Makro içeren bir sunumu yüklemek için [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Sunumun bir [VBA projesi](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/vbaproject/) içerip içermediğini kontrol edin.
3. VBA projesinin parola korumalı olup olmadığını kontrol ederek özelliklerini görüntüleyin.

```js
let presentation = new aspose.slides.Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // Sunumun bir VBA projesi içerip içermediğini kontrol eder.
        if (presentation.getVbaProject().isPasswordProtected()) {
            console.log("The VBA Project '%s' is protected by password to view project properties.", 
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

**Aspose.Slides bir sunumdaki makroları, örneğin verileri yenilemek için çalıştırabilir mi?**

Hayır. Kütüphane VBA kodunu asla çalıştırmaz; yürütme yalnızca uygun güvenlik ayarlarıyla PowerPoint içinde mümkündür.

**VBA koduna bağlı ActiveX denetimlerini kullanmak destekleniyor mu?**

Evet, mevcut [ActiveX controls](/slides/tr/nodejs-java/activex/) üzerine erişebilir, özelliklerini değiştirebilir ve kaldırabilirsiniz. Bu, makroların ActiveX ile etkileşime girdiği durumlarda faydalıdır.