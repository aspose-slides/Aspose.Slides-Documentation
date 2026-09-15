---
title: Python ile Sunumlarda VBA Projelerini Yönetme
linktitle: VBA ile Sunum
type: docs
weight: 250
url: /tr/python-java/presentation-via-vba/
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
- Java
- Aspose.Slides
description: "VBA ile PowerPoint ve OpenDocument sunumlarını oluşturmayı ve düzenlemeyi, Python için Java aracılığıyla Aspose.Slides kullanarak iş akışınızı kolaylaştırmayı keşfedin."
---
## **Giriş**

Aspose.Slides makrolar ve VBA kodu ile çalışmak için sınıflar ve arabirimler sağlar.

{{% alert title="Warning" color="warning" %}} 

Makrolar içeren bir sunumu farklı bir dosya biçimine (PDF, HTML vb.) dönüştürdüğünüzde, Aspose.Slides tüm makroları yok sayar (makrolar oluşan dosyaya taşınmaz).

Sunuma makrolar eklediğinizde veya makrolar içeren bir sunumu yeniden kaydettiğinizde, Aspose.Slides makroların baytlarını sadece yazar.

Aspose.Slides **asla** bir sunumdaki makroları çalıştırmaz.

{{% /alert %}}

## **VBA Makroları Ekleme**

Aspose.Slides, VBA projeleri (ve proje referansları) oluşturmanıza ve mevcut modülleri düzenlemenize olanak tanıyan [VbaProject](https://reference.aspose.com/slides/tr/python-java/aspose.slides/vbaproject/) sınıfını sağlar. Sunuma gömülü VBA'yı yönetmek için [VbaProject](https://reference.aspose.com/slides/tr/python-java/aspose.slides/vbaproject/) sınıfını kullanabilirsiniz.

1. İlk olarak [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Yeni bir VBA projesi eklemek için [VbaProject](https://reference.aspose.com/slides/tr/python-java/aspose.slides/vbaproject/#vbaproject) yapıcısını kullanın.
3. VBA projesine bir modül ekleyin.
4. Modülün kaynak kodunu ayarlayın.
5. `stdole` referanslarını ekleyin.
6. **Microsoft Office** referanslarını ekleyin.
7. Referansları VBA projesiyle ilişkilendirin.
8. Sunumu kaydedin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VbaProject, VbaReferenceOleTypeLib

presentation = Presentation()
try:
    # Yeni bir VBA projesi oluştur.
    vba_project = VbaProject()
    presentation.setVbaProject(vba_project)

    # Boş bir modül ekle ve kaynak kodunu ayarla.
    module = vba_project.getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test(oShape As Shape)\n    MsgBox "Test"\nEnd Sub')

    # stdole ve Microsoft Office referanslarını oluştur.
    stdole_reference = VbaReferenceOleTypeLib("stdole", r"*\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\Windows\system32\stdole2.tlb#OLE Automation")
    office_reference = VbaReferenceOleTypeLib("Office", r"*\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\Program Files\Common Files\Microsoft Shared\OFFICE14\MSO.DLL#Microsoft Office 14.0 Object Library")

    # VBA projesine referansları ekle.
    vba_project.getReferences().add(stdole_reference)
    vba_project.getReferences().add(office_reference)

    # Sunumu kaydet.
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 

**Aspose** [Macro Remover](https://products.aspose.app/slides/tr/remove-macros) uygulamasına göz atmak isteyebilirsiniz; bu, PowerPoint, Excel ve Word belgelerindeki makroları kaldırmak için kullanılan ücretsiz bir web uygulamasıdır. 

{{% /alert %}} 

## **VBA Makrolarını Kaldırma**

[Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının [getVbaProject](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getvbaproject) metodunu kullanarak bir VBA makrosunu kaldırabilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun ve makroyu içeren sunumu yükleyin.
2. Makro modülüne erişin ve onu kaldırın.
3. Değiştirilen sunumu kaydedin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Makroyu içeren sunumu yükle.
presentation = Presentation("VBA.pptm")
try:
    # VBA modülüne eriş ve onu kaldır.
    vba_project = presentation.getVbaProject()
    if vba_project is not None and len(list(vba_project.getModules())) > 0:
        module = vba_project.getModules().get_Item(0)
        vba_project.getModules().remove(module)

    # Sunumu kaydet.
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **VBA Makrolarını Çıkarma**

1. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun ve makroyu içeren sunumu yükleyin.
2. Sunumun bir VBA Projesi içerip içermediğini kontrol edin.
3. Makroları görüntülemek için VBA Projesi içindeki tüm modülleri döngüyle gezinin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# Makroyu içeren sunumu yükle.
presentation = Presentation("VBA.pptm")
try:
    # Sunumun bir VBA projesi içerip içermediğini kontrol et.
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        for module in vba_project.getModules():
            print(module.getName())
            print(module.getSourceCode())
finally:
    presentation.dispose()
```

## **VBA Projesinin Parola Koruması Olup Olmadığını Kontrol Etme**

[VbaProject.isPasswordProtected](https://reference.aspose.com/slides/tr/python-java/aspose.slides/vbaproject/#ispasswordprotected) metodunu kullanarak bir projenin özelliklerinin parola korumalı olup olmadığını belirleyebilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun ve bir makro içeren sunumu yükleyin.
2. Sunumun bir [VBA projesi](https://reference.aspose.com/slides/tr/python-java/aspose.slides/vbaproject/) içerip içermediğini kontrol edin.
3. VBA projesinin özelliklerini görüntülemek için parola korumalı olup olmadığını kontrol edin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("VBA.pptm")
try:
    # Sunumun bir VBA projesi içerip içermediğini kontrol et.
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        if vba_project.isPasswordProtected():
            print(f"The VBA project '{vba_project.getName()}' is password-protected for viewing its properties.")
finally:
    presentation.dispose()
```

## **SSS**

**Sunumu PPTX olarak kaydedersem makrolar ne olur?**

PPTX VBA'yı desteklemediği için makrolar kaldırılacaktır. Makroları korumak istiyorsanız PPTM, PPSM veya POTM formatlarını seçin.

**Aspose.Slides bir sunumdaki makroları çalıştırabilir mi, örneğin verileri yenilemek gibi?**

Hayır. Kütüphane VBA kodunu asla çalıştırmaz; yürütme yalnızca uygun güvenlik ayarlarına sahip PowerPoint içinde mümkündür.

**VBA koduna bağlanan ActiveX denetimleriyle çalışmak destekleniyor mu?**

Evet, mevcut [ActiveX denetimlerine](/slides/tr/python-java/activex/), erişebilir, özelliklerini değiştirebilir ve kaldırabilirsiniz. Bu, makroların ActiveX ile etkileşime girdiği durumlarda yararlıdır.