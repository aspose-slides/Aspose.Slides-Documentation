---
title: PHP ile Sunumlarda VBA Projelerini Yönetme
linktitle: VBA ile Sunum
type: docs
weight: 250
url: /tr/php-java/presentation-via-vba/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile VBA aracılığıyla PowerPoint ve OpenDocument sunumları oluşturmayı ve yönetmeyi keşfedin, iş akışınızı kolaylaştırın."
---
## **Giriş**

Aspose.Slides API, makrolar ve VBA kodlarıyla çalışmak için sınıflar içerir.

{{% alert title="Not" color="warning" %}} 

Bir sunumu makrolar içerecek şekilde farklı bir dosya formatına (PDF, HTML, vb.) dönüştürdüğünüzde Aspose.Slides tüm makroları yok sayar (makrolar sonuç dosyasına aktarılmaz).

Bir sunuma makro eklediğinizde veya makro içeren bir sunumu yeniden kaydettiğinizde Aspose.Slides yalnızca makroların baytlarını yazar.

Aspose.Slides **asla** bir sunumdaki makroları çalıştırmaz.

{{% /alert %}}

## **VBA Makroları Ekleme**

Aspose.Slides, VBA projeleri (ve proje referansları) oluşturmanıza ve mevcut modülleri düzenlemenize olanak tanıyan [VbaProject](https://reference.aspose.com/slides/tr/php-java/aspose.slides/vbaproject/) sınıfını sağlar. `VbaProject` sınıfını bir sunuma gömülü VBA'yı yönetmek için kullanabilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. Yeni bir VBA projesi eklemek için [VbaProject](https://reference.aspose.com/slides/tr/php-java/aspose.slides/vbaproject/#VbaProject) yapıcısını kullanın.
1. VbaProject'e bir modül ekleyin.
1. Modül kaynak kodunu ayarlayın.
1. <stdole> referanslarını ekleyin.
1. **Microsoft Office** referanslarını ekleyin.
1. Referansları VBA projesiyle ilişkilendirin.
1. Sunumu kaydedin.

Bu PHP kodu, bir sunuma sıfırdan VBA makrosu eklemenin nasıl yapılacağını gösterir:

```php
  # Sunum sınıfının bir örneğini oluşturur
  $pres = new Presentation();
  try {
    # Yeni bir VBA Projesi oluşturur
    $pres->setVbaProject(new VbaProject());
    # VBA projesine boş bir modül ekler
    $module = $pres->getVbaProject()->getModules()->addEmptyModule("Module");
    # Modül kaynak kodunu ayarlar
    $module->setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    # <stdole>'a bir referans oluşturur
    $stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    # Office'e bir referans oluşturur
    $officeReference = new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    # VBA projesine referansları ekler
    $pres->getVbaProject()->getReferences()->add($stdoleReference);
    $pres->getVbaProject()->getReferences()->add($officeReference);
    # Sunumu kaydeder
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

**Aspose** [Macro Remover](https://products.aspose.app/slides/tr/remove-macros) adlı, PowerPoint, Excel ve Word belgelerinden makroları kaldırmak için kullanılan ücretsiz bir web uygulamasını inceleyebilirsiniz. 

{{% /alert %}} 

## **VBA Makroları Kaldırma**

[Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfının altındaki [VbaProject](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getVbaProject) özelliğini kullanarak bir VBA makrosunu kaldırabilirsiniz.

1. Makro içeren sunumu yükleyerek [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. Makro modülüne erişin ve onu kaldırın.
1. Değiştirilmiş sunumu kaydedin.

Bu PHP kodu, bir VBA makrosunu nasıl kaldıracağınızı gösterir:

```php
  # Makroyu içeren sunumu yükler
  $pres = new Presentation("VBA.pptm");
  try {
    # Vba modülüne erişir ve onu kaldırır
    $pres->getVbaProject()->getModules()->remove($pres->getVbaProject()->getModules()->get_Item(0));
    # Sunumu kaydeder
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **VBA Makrolarını Çıkarma**

1. Makro içeren sunumu yükleyerek [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
2. Sunumun bir VBA Projesi içerip içermediğini kontrol edin.
3. VBA Projesinde bulunan tüm modülleri döngüye alarak makroları görüntüleyin.

Bu PHP kodu, makrolar içeren bir sunumdan VBA makrolarını nasıl çıkaracağınızı gösterir:

```php
  # Makroyu içeren sunumu yükler
  $pres = new Presentation("VBA.pptm");
  try {
    # Sunumun bir VBA Projesi içerip içermediğini kontrol eder
    if (!java_is_null($pres->getVbaProject())) {
      foreach($pres->getVbaProject()->getModules() as $module) {
        echo($module->getName());
        echo($module->getSourceCode());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Bir VBA Projesinin Parola Koruması Olup Olmadığını Kontrol Etme**

[VbaProject::isPasswordProtected](https://reference.aspose.com/slides/tr/php-java/aspose.slides/vbaproject/#isPasswordProtected) yöntemini kullanarak bir projenin özelliklerinin parola korumalı olup olmadığını belirleyebilirsiniz.

1. Makro içeren bir sunumu yükleyerek [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Sunumun bir [VBA project](https://reference.aspose.com/slides/tr/php-java/aspose.slides/vbaproject/) içerip içermediğini kontrol edin.
3. VBA projesinin parola korumalı olup olmadığını kontrol ederek özelliklerini görüntüleyin.

```php
$presentation = new Presentation("VBA.pptm");
try {
    if ($presentation->getVbaProject() != null) { // Sunumun bir VBA projesi içerip içermediğini kontrol eder.
        if ($presentation->getVbaProject()->isPasswordProtected()) {
            printf("The VBA Project '%s' is protected by password to view project properties.", 
                    $presentation->getVbaProject()->getName());
        }
    }
} finally {
    $presentation->dispose();
}
```

## **SSS**

**Sunumu PPTX olarak kaydedersem makrolar ne olur?**

Makrolar kaldırılır, çünkü PPTX VBA'yı desteklemez. Makroları korumak için PPTM, PPSM veya POTM seçin.

**Aspose.Slides bir sunum içindeki makroları çalıştırabilir mi, örneğin verileri yenilemek gibi?**

Hayır. Kütüphane hiçbir zaman VBA kodunu çalıştırmaz; yürütme yalnızca PowerPoint içinde uygun güvenlik ayarlarıyla mümkündür.

**VBA koduna bağlı ActiveX denetimlerinin kullanımı destekleniyor mu?**

Evet, mevcut [ActiveX controls](/slides/tr/php-java/activex/) erişebilir, özelliklerini değiştirebilir ve kaldırabilirsiniz. Bu, makroların ActiveX ile etkileşimde bulunduğu durumlarda faydalıdır.