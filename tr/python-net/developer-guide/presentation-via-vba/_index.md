---
title: Python ile Sunumlarda VBA Projelerini Yönetme
linktitle: VBA ile Sunum
type: docs
weight: 250
url: /tr/python-net/presentation-via-vba/
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
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak VBA aracılığıyla PowerPoint ve OpenDocument sunumları oluşturmayı ve düzenlemeyi keşfedin ve iş akışınızı kolaylaştırın."
---
## **Genel Bakış**

Bu makale, PowerPoint sunumlarındaki makrolarla çalışmak için .NET üzerinden Python için Aspose.Slides’ın temel yeteneklerini inceler. Kütüphane, makroları ekleme, kaldırma ve çıkarma için kullanışlı araçlar sağlar; bu da sunumların oluşturulmasını ve değiştirilmesini otomatikleştirmenize olanak tanır.

Aspose.Slides ile şunları yapabilirsiniz:

- Sunum geliştirmeyi hızlandırın—rutin görevlerin otomasyonu, materyalleri hazırlama süresini azaltır.
- Esnekliği sağlayın—makroları yönetme yeteneği, sunumları belirli görev ve senaryolara göre özelleştirmenizi sağlar.
- Veriyi entegre edin—harici veri kaynaklarıyla basit entegrasyon, slayt içeriğinin güncel kalmasına yardımcı olur.
- Bakımı basitleştirin—merkezi makro yönetimi, değişiklik uygulamayı ve sunumları güncellemeyi kolaylaştırır.

Makrolarla PowerPoint'te etkili bir şekilde çalışmak için Aspose.Slides kullanımına yönelik pratik örnekler makalede sunulmaktadır.

[aspose.slides.vba](https://reference.aspose.com/slides/tr/python-net/aspose.slides.vba/) ad alanı, makrolar ve VBA kodu ile çalışmak için sınıflar sunar.

{{% alert title="Note" color="warning" %}}
Makrolar içeren bir sunumu başka bir formata (PDF, HTML, vb.) dönüştürdüğünüzde, Aspose.Slides makroları görmezden gelir—çıktı dosyasına aktarılmazlar.

Sunuma makro eklediğinizde veya makrolar içeren bir sunumu yeniden kaydettiğinizde, Aspose.Slides makro baytlarını olduğu gibi yazar.

Aspose.Slides **asla** bir sunumdaki makroları çalıştırmaz.
{{% /alert %}}

## **VBA Makroları Ekle**

Aspose.Slides, VBA projeleri (ve proje referansları) oluşturmak ve mevcut modülleri düzenlemek için [VbaProject](https://reference.aspose.com/slides/tr/python-net/aspose.slides.vba/vbaproject/) sınıfını sağlar.

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfından bir örnek oluşturun.  
1. Yeni bir VBA projesi eklemek için [VbaProject](https://reference.aspose.com/slides/tr/python-net/aspose.slides.vba/vbaproject/#constructors) yapıcısını kullanın.  
1. VBA projesine bir modül ekleyin.  
1. Modülün kaynak kodunu ayarlayın.  
1. `<stdole>` için bir referans ekleyin.  
1. **Microsoft Office** için bir referans ekleyin.  
1. Referansları VBA projesiyle ilişkilendirin.  
1. Sunumu kaydedin.

Aşağıdaki Python kodu, bir sunuma sıfırdan VBA makrosu eklemeyi gösterir:

```python
import aspose.slides as slides

# Presentation sınıfının bir örneğini oluştur.
with slides.Presentation() as presentation:

    # Yeni bir VBA projesi oluştur.
    presentation.vba_project = slides.vba.VbaProject()

    # VBA projesine boş bir modül ekle.
    module = presentation.vba_project.modules.add_empty_module("Module")

    # Modül kaynak kodunu ayarla.
    module.source_code = """
        Sub Test(oShape As Shape)
            MsgBox "Hello, world!"
        End Sub
    """

    # <stdole> referansı oluştur.
    stdole_reference = slides.vba.VbaReferenceOleTypeLib("stdole",
        "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation")

    # Microsoft Office referansı oluştur.
    office_reference = slides.vba.VbaReferenceOleTypeLib("Office",
        "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library")

    # Referansları VBA projesine ekle.
    presentation.vba_project.references.add(stdole_reference)
    presentation.vba_project.references.add(office_reference)

    # Sunumu kaydet.
    presentation.save("macros.pptm", slides.export.SaveFormat.PPTM)
```

{{% alert color="primary" %}}
**Aspose** [Macro Remover](https://products.aspose.app/slides/tr/remove-macros) adlı, PowerPoint, Excel ve Word belgelerinden makroları kaldırmak için ücretsiz bir web uygulamasını denemek isteyebilirsiniz.
{{% /alert %}}

## **VBA Makrolarını Kaldırma**

[Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının [vba_project](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/vba_project/) özelliğini kullanarak bir VBA makrosunu kaldırabilirsiniz.

1. Makroyu içeren sunumu yükleyerek [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfından bir örnek oluşturun.  
1. Makro modülüne erişin ve onu kaldırın.  
1. Değiştirilmiş sunumu kaydedin.

Aşağıdaki Python kodu, bir VBA makrosunu kaldırmayı gösterir:

```python
import aspose.slides as slides

# Makroyu içeren sunumu yükle.
with slides.Presentation("VBA.pptm") as presentation:
    
    # VBA modülüne eriş.
    vba_module = presentation.vba_project.modules[0]

    # VBA modülünü kaldır.
    presentation.vba_project.modules.remove(vba_module)

    # Sunumu kaydet.
    presentation.save("removed_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **VBA Makrolarını Çıkarma**

[VbaProject](https://reference.aspose.com/slides/tr/python-net/aspose.slides.vba/vbaproject/) sınıfındaki `modules` özelliğini kullanarak bir VBA projesinin tüm modüllerine erişebilirsiniz. [VbaModule](https://reference.aspose.com/slides/tr/python-net/aspose.slides.vba/vbamodule/) sınıfı, ad ve kod gibi modül özelliklerini çıkarmak için kullanılabilir.

1. Makroyu içeren sunumu yükleyerek [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfından bir örnek oluşturun.  
1. Sunumun bir VBA projesi içerip içermediğini kontrol edin.  
1. VBA projesindeki tüm modülleri dolaşarak makroları görüntüleyin.

Aşağıdaki Python kodu, bir sunumdan VBA makrolarını çıkarmayı gösterir:

```python
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Sunumun bir VBA projesi içerip içermediğini kontrol et.
    if presentation.vba_project is not None:
        for module in presentation.vba_project.modules:
            print(module.name)
            print(module.source_code)
```

## **VBA Projesinin Şifre Koruması Olup Olmadığını Kontrol Etme**

[VbaProject.is_password_protected](https://reference.aspose.com/slides/tr/python-net/aspose.slides.vba/vbaproject/is_password_protected/) özelliğini kullanarak bir projenin özelliklerinin şifre korunup korunmadığını belirleyebilirsiniz.

1. Makro içeren bir sunumu yükleyerek [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfından bir örnek oluşturun.  
1. Sunumun bir [VBA projesi](https://reference.aspose.com/slides/tr/python-net/aspose.slides.vba/vbaproject/) içerip içermediğini kontrol edin.  
1. VBA projesinin şifre korumalı olup olmadığını kontrol ederek özelliklerini görüntüleyin.

```py
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Sunumun bir VBA projesi içerip içermediğini kontrol et.
    if presentation.vba_project is not None:
        if presentation.vba_project.is_password_protected:
            print(f"The VBA Project '{presentation.vba_project.name}' is protected by password to view project properties.")
```

## **SSS**

**Sunumu PPTX olarak kaydedersem makrolar ne olur?**  

Makrolar kaldırılır çünkü PPTX VBA’yı desteklemez. Makroları korumak için PPTM, PPSM veya POTM formatlarını seçin.

**Aspose.Slides bir sunum içindeki makroları çalıştırıp veriyi yenileyebilir mi?**  

Hayır. Kütüphane VBA kodunu asla çalıştırmaz; yürütme yalnızca PowerPoint içinde, uygun güvenlik ayarlarıyla mümkündür.

**VBA koduna bağlı ActiveX denetimleriyle çalışmak destekleniyor mu?**  

Evet, mevcut [ActiveX controls](/slides/tr/python-net/activex/) öğelerine erişebilir, özelliklerini değiştirebilir ve kaldırabilirsiniz. Bu, makroların ActiveX ile etkileşime girdiği senaryolarda faydalıdır.