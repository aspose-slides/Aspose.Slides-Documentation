---
title: Python ile Sunumlarda ActiveX Kontrollerini Yönet
linktitle: ActiveX
type: docs
weight: 80
url: /tr/python-java/activex/
keywords:
- ActiveX
- ActiveX denetimi
- ActiveX yönetimi
- ActiveX ekle
- ActiveX değiştir
- medya oynatıcı
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile PowerPoint sunumlarında ActiveX metin kutularını ve düğmelerini düzenleyin, denetim önizlemelerini güncelleyin ve Windows Media Player denetimini yeniden kullanın."
---
## **Giriş**

ActiveX denetimleri, bir PowerPoint slaytına metin kutuları, komut düğmeleri ve medya oynatıcıları gibi etkileşimli öğeler ekler. Aspose.Slides for Python via Java, bir slaydın denetimlerini [BaseSlide.getControls](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getControls) aracılığıyla ortaya çıkarır. Bu koleksiyonu bir denetimi düzenlemek, slayt üzerinde taşımak veya kaldırmak için kullanın.

## **ActiveX Kontrollerini ve Saklanan Özelliklerini Listele**

Tanıdık olmayan bir şablonu incelemek için, dosyayı okuma modunda açın ve her slayttaki denetimler üzerinde döngü yapın. Örnek, slayt numarasını, denetim adını, [getClassId](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getClassId) ve [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties) içindeki her anahtar-değer çiftini rapor eder. Sunumu, denetimleri etkinleştirmeden, olayları veya makroları çalıştırmadan, değerleri değiştirmeden veya dosyayı kaydetmeden okur.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("ActiveX.pptm")
try:
    for slide_number, slide in enumerate(presentation.getSlides(), start=1):
        for control in slide.getControls():
            print(f"Slide {slide_number} | {control.getName()} | {control.getClassId()}")
            properties = control.getProperties()
            if properties is None:
                print("  Properties unavailable")
            elif properties.getCount() == 0:
                print("  []")
            else:
                for name in properties.getNamesOfProperties():
                    print(f"  {name} = {properties.get_Item(name)}")
finally:
    presentation.dispose()
```

`ActiveX.pptm` dosyasından seçilen çıktı bir metin kutusunu ve bir komut düğmesini gösterir.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Boş bir özellik koleksiyonu `[]` olarak görüntülenir. İkili depolama kullanan denetimler için, [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties) `None` döndürebilir; bu da `Properties unavailable` olarak gösterilir. Yalnızca adlara ihtiyacınız varsa, koleksiyonun mevcut olduğunu kontrol ettikten sonra [getNamesOfProperties](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) kullanın. Rapor, sunumda mevcut olan özellikleri listeler. Bir denetim, çalışma zamanında ek özellikleri destekleyebilir.

## **ActiveX Kontrollerini Değiştir**

Örnek, birinci slaytta `TextBox1` adlı bir metin kutusu ve `CommandButton1` adlı bir komut düğmesi içeren makro etkin bir sunum bekler. Metin kutusu değerini ve düğme başlığını değiştirmek için [control properties collection](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) kullanır. Her denetimin, PowerPoint'in etkinleştirmeden önce görüntüleyebileceği statik bir önizlemesi de vardır. Güncellenmiş metin ve görünümünü gösteren bir PNG dosyasını her denetim için sağlayın. Örnek, bu görselleri [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getSubstitutePictureFormat) aracılığıyla atar.

Örnek, birinci slayttaki tüm denetimleri [Control.setFrame](https://reference.aspose.com/slides/python-java/aspose.slides/control/#setFrame) kullanarak çerçevesini ayarlayarak 100 puan aşağı kaydırır. Düzenlenmiş sunumu PPTM formatında kaydeder, ardından [ControlCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/controlcollection/#clear) kullanarak o slayttan tüm ActiveX denetimlerini kaldırılmış ikinci bir kopya kaydeder.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeFrame

presentation = Presentation("ActiveX.pptm")
try:
    controls = presentation.getSlides().get_Item(0).getControls()
    by_name = {str(control.getName()): control for control in controls}
    text_box = by_name.get("TextBox1")
    button = by_name.get("CommandButton1")
    if text_box is None or button is None or text_box.getProperties() is None or button.getProperties() is None:
        print("The first slide must contain both named controls with editable properties.")
    else:
        text_box_bytes = Path("text-box-preview.png").read_bytes()
        button_bytes = Path("button-preview.png").read_bytes()
        text_box_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(text_box_bytes))
        button_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(button_bytes))
        text_box.getProperties().set_Item("Value", "Changed text")
        button.getProperties().set_Item("Caption", "Show message")
        text_box.getSubstitutePictureFormat().getPicture().setImage(text_box_preview)
        button.getSubstitutePictureFormat().getPicture().setImage(button_preview)

        for control in controls:
            frame = control.getFrame()
            moved = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(moved)
        presentation.save("edited-controls.pptm", SaveFormat.Pptm)

        controls.clear()
        presentation.save("removed-controls.pptm", SaveFormat.Pptm)
except OSError as error:
    print(f"Could not read a control preview: {error}")
finally:
    presentation.dispose()
```

## **Bir ActiveX Medya Oynatıcı Denetimi Ekle**

Yapılandırılmış bir Windows Media Player denetimini yeniden kullanmak için, birinci slaytında `WindowsMediaPlayer1` adlı bir oynatıcı bulunan bir şablonla başlayın. [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) tüm slaytı yeni bir sunuma kopyalar. Örnek, oynatıcının `URL`'sini [properties collection](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) içinde ayarlar ve kopyalanan slaytı çıktının tek slaytı olarak kaydeder. Video harici kalır, bu yüzden oynatıcı oynatma sırasında erişebileceği bir yol seçin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

template = Presentation("template.pptx")
try:
    presentation = Presentation()
    try:
        slides = presentation.getSlides()
        slide = slides.addClone(template.getSlides().get_Item(0))
        player = next((control for control in slide.getControls() if control.getName() == "WindowsMediaPlayer1"), None)
        if player is None or player.getProperties() is None:
            print("The template slide must contain a named media player with editable properties.")
        else:
            player.getProperties().set_Item("URL", "Wildlife.mp4")
            slides.removeAt(0)
            presentation.save("linked-video.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    template.dispose()
```

## **SSS**

**Aspose.Slides ActiveX denetimlerini çalıştırmadan koruyabilir mi?**  
Evet. Aspose.Slides, denetimlerin özellikleri ve konumları dahil olmak üzere, denetimleri etkinleştirmeden okuyabilir ve kaydedebilir.

**ActiveX denetimleri OLE nesnelerinden nasıl farklıdır?**  
ActiveX denetimleri, kullanıcıların bir slayt ile etkileşime girmesini sağlar; örneğin metin girme veya bir düğmeye tıklama gibi. Bir [OLE object](/slides/tr/python-java/manage-ole/) ise bir slaydın, başka bir uygulama tarafından yönetilen bir içeriği (örneğin bir Excel çalışma sayfası) içermesine veya ona bağlanmasına olanak tanır.

**AktifX olayları, bir sunumu Aspose.Slides ile kaydettikten sonra VBA makrolarını tetiklemeye devam eder mi?**  
VBA projesini korumak için sunumu PPTM gibi makro etkin bir formatta kaydedin. Windows için PowerPoint, güvenlik ayarları hem ActiveX denetimlerine hem de makrolara izin verdiğinde mevcut olay işleyicilerini çalıştırabilir.