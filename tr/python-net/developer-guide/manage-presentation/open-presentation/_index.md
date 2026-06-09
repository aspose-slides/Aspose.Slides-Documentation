---
title: Python'da Sunumları Açma
linktitle: Sunumları Açma
type: docs
weight: 20
url: /tr/python-net/open-presentation/
keywords:
- PowerPoint aç
- sunum aç
- PPTX aç
- PPT aç
- ODP aç
- sunum yükle
- PPTX yükle
- PPT yükle
- ODP yükle
- korumalı sunum
- büyük sunum
- dış kaynak
- ikili nesne
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PowerPoint (.pptx, .ppt) ve OpenDocument (.odp) sunumlarını zahmetsizce açın—hızlı, güvenilir, tam özellikli."
---
## **Giriş**

Sıfırdan PowerPoint sunumları oluşturmanın yanı sıra, Aspose.Slides mevcut sunumları da açmanıza olanak tanır. Bir sunumu yükledikten sonra, onunla ilgili bilgileri alabilir, slayt içeriğini düzenleyebilir, yeni slaytlar ekleyebilir, mevcut olanları kaldırabilir ve daha fazlasını yapabilirsiniz.

## **Sunumları Açma**

Mevcut bir sunumu açmak için, [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun ve dosya yolunu yapıcıya geçirin.

Aşağıdaki Python örneği, bir sunumu nasıl açıp slayt sayısını alacağınızı gösterir:

```python
import aspose.slides as slides

# Presentation sınıfının bir örneğini oluşturun ve dosya yolunu yapıcıya geçirin.
with slides.Presentation("sample.pptx") as presentation:
    # Sunumdaki toplam slayt sayısını yazdırın.
    print(presentation.slides.length)
```

## **Şifre Koruması Olan Sunumları Açma**

Şifre korumalı bir sunumu açmanız gerektiğinde, şifreyi [password](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/password/) özelliği aracılığıyla [LoadOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/) sınıfına geçirerek şifreyi çözebilir ve yükleyebilirsiniz. Aşağıdaki Python kodu bu işlemi gösterir:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # Şifrelenmiş sunumda işlemler gerçekleştirin.
```

## **Büyük Sunumları Açma**

Aspose.Slides, büyük sunumları yüklemenize yardımcı olmak için seçenekler sunar—özellikle [blob_management_options](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/blob_management_options/) özelliği, [LoadOptions] sınıfında.

Bu Python kodu, büyük bir sunumu (örneğin 2 GB) yüklemeyi gösterir:

```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# KeepLocked davranışını seçin—sunum dosyası, 
# Presentation örneği süresince kilitli kalır, ancak belleğe yüklenmesine veya geçici bir dosyaya kopyalanmasına gerek yoktur.
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 MB

with slides.Presentation(file_path, load_options) as presentation:
    # Büyük sunum yüklendi ve kullanılabilir, bellek tüketimi düşük kalır.

    # Sunumu değiştirin.
    presentation.slides[0].name = "Large presentation"

    # Sunumu başka bir dosyaya kaydedin. Bu işlem sırasında bellek tüketimi düşük kalır.
    presentation.save("LargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # Bunu yapmayın! Dosya sunum nesnesi serbest bırakılana kadar kilitli olduğu için bir I/O istisnası fırlatılacaktır.
    os.remove(file_path)

# Burada yapmak sorun değil. Kaynak dosya artık sunum nesnesi tarafından kilitlenmemektedir.
os.remove(file_path)
```

{{% alert color="info" title="Bilgi" %}}
Akışlarla çalışırken belirli sınırlamaları aşmak için Aspose.Slides akışın içeriğini kopyalayabilir. Bir akıştan büyük bir sunum yüklemek, sunumun kopyalanmasına ve yükleme süresinin yavaşlamasına neden olur. Bu nedenle, büyük bir sunumu yüklemeniz gerektiğinde, akış yerine sunum dosya yolunu kullanmanızı şiddetle öneririz.

Büyük nesneler (video, ses, yüksek çözünürlüklü görseller vb.) içeren bir sunum oluştururken, bellek tüketimini azaltmak için [BLOB yönetimi](/slides/tr/python-net/manage-blob/) kullanabilirsiniz.
{{%/alert %}}

## **Gömülü Binary Nesneler Olmadan Sunum Yükleme**

Bir PowerPoint sunumu aşağıdaki türde gömülü binary nesneler içerebilir:

- VBA projesi (erişim: [Presentation.vba_project](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/vba_project/));
- OLE nesnesi gömülü veri (erişim: [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/));
- ActiveX kontrol binary verisi (erişim: [Control.active_x_control_binary](https://reference.aspose.com/slides/tr/python-net/aspose.slides/control/active_x_control_binary/)).

[LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) özelliğini kullanarak, gömülü binary nesneleri olmadan bir sunum yükleyebilirsiniz.

Bu özellik, potansiyel kötü amaçlı binary içeriği kaldırmak için yararlıdır. Aşağıdaki Python kodu, gömülü binary içeriği olmayan bir sunumun nasıl yükleneceğini gösterir:

```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # Sunumda işlemler gerçekleştirin.
```

## **SSS**

**Bir dosyanın bozuk olduğunu ve açılamadığını nasıl anlayabilirim?**

Yükleme sırasında bir ayrıştırma/form doğrulama istisnası alırsınız. Bu hatalar genellikle geçersiz ZIP yapısı veya bozuk PowerPoint kayıtlarından bahseder.

**Açarken gerekli yazı tipleri eksik olursa ne olur?**

Dosya açılacaktır, ancak daha sonra [görselleştirme/ihracat](/slides/tr/python-net/convert-presentation/) yazı tiplerini değiştirebilir. Çalışma zamanına [Yazı tipi yerine koyma yapılandırması](/slides/tr/python-net/font-substitution/) veya [gereken yazı tiplerini ekle](/slides/tr/python-net/custom-font/) ekleyin.

**Açarken gömülü medya (video/ses) ne olur?**

Bunlar sunum kaynakları olarak erişilebilir olur. Medya dış yollarla referans verilmişse, bu yolların ortamınızda erişilebilir olduğundan emin olun; aksi takdirde [görselleştirme/ihracat](/slides/tr/python-net/convert-presentation/) medya dışarıda bırakılabilir.