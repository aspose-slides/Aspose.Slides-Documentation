---
title: Python ile Sunumlarda ActiveX Denetimlerini Yönetin
linktitle: ActiveX
type: docs
weight: 80
url: /tr/python-net/activex/
keywords:
- ActiveX
- ActiveX denetimi
- ActiveX yönetimi
- ActiveX ekleme
- ActiveX değiştirme
- medya oynatıcı
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "ActiveX metin kutularını ve düğmelerini düzenleyin, denetim önizlemelerini güncelleyin ve Aspose.Slides for Python via .NET ile PowerPoint sunumlarında bir Windows Media Player denetimini yeniden kullanın."
---
## **Giriş**

ActiveX denetimleri, bir PowerPoint slaytına metin kutuları, komut düğmeleri ve medya oynatıcıları gibi etkileşimli öğeler ekler. Aspose.Slides for Python via .NET, bir slaydın denetimlerini [Slide.controls](https://reference.aspose.com/slides/python-net/aspose.slides/slide/controls/) aracılığıyla ortaya çıkar. Bu koleksiyonu bir denetimi düzenlemek, slayt üzerinde taşımak veya kaldırmak için kullanın.

## **ActiveX Denetimlerini ve Saklanan Özelliklerini Listele**

Tanıdık olmayan bir şablonu incelemek için, şablonu okuma modunda açın ve her slayttaki denetimler üzerinde yineleyin. Örnek, slayt numarasını, denetim adını, [class_id](https://reference.aspose.com/slides/python-net/aspose.slides/control/class_id/) ve [properties](https://reference.aspose.com/slides/python-net/aspose.slides/control/#properties) içindeki her anahtar‑değer çiftini raporlar. Sunumu, denetimleri etkinleştirmeden, olayları veya makroları tetiklemeden, değerleri değiştirmeden veya dosyayı kaydetmeden okur.

```python
import aspose.slides as slides

with slides.Presentation("ActiveX.pptm") as presentation:
    for slide_number, slide in enumerate(presentation.slides, start=1):
        for control in slide.controls:
            print(f"Slide {slide_number} | {control.name} | {control.class_id}")
            properties = control.properties
            if properties is None:
                print("  Properties unavailable")
                continue

            if properties.count == 0:
                print("  []")
            for entry in properties:
                print(f"  {entry.key} = {entry.value}")
```

`ActiveX.pptm` dosyasından seçilen çıktı bir metin kutusu ve bir komut düğmesi gösterir.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Boş bir özellik koleksiyonu `[]` şeklinde görünür. İkili depolama kullanan denetimler için `properties` `None` dönebilir ve bu `Properties unavailable` olarak gösterilir. Sadece adlara ihtiyacınız varsa, `None` kontrolünden sonra [names_of_properties](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/names_of_properties/) kullanın. Rapor, sunumdan elde edilebilen özellikleri listeler. Bir denetim, çalışma zamanında ek özellikler destekleyebilir.

## **ActiveX Denetimlerini Değiştir**

Örnek, ilk slaytta `TextBox1` adlı bir metin kutusu ve `CommandButton1` adlı bir komut düğmesi bulunan makro‑etkin bir sunum bekler. Metin kutusu değerini ve düğme başlığını değiştirmek için [denetim özellikleri koleksiyonu](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) kullanır. Her denetimin, PowerPoint'in etkinleştirmeden önce görüntüleyebileceği statik bir önizlemesi de vardır. Güncellenmiş metin ve görünümlerini gösteren bir PNG dosyasını her denetim için sağlayın. Örnek, bu görüntüleri [Control.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/control/substitute_picture_format/) aracılığıyla atar.

Örnek, ilk slayttaki tüm denetimleri [frame](https://reference.aspose.com/slides/python-net/aspose.slides/control/frame/) özelliğini değiştirerek 100 puan aşağı kaydırır. Düzenlenmiş sunumu PPTM formatında kaydeder, ardından [ControlCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/controlcollection/clear/) kullanarak o slayttan tüm ActiveX denetimlerini kaldırılmış ikinci bir kopya kaydeder.

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation("ActiveX.pptm") as presentation:
    controls = presentation.slides[0].controls
    text_box = next((control for control in controls if control.name == "TextBox1"), None)
    button = next((control for control in controls if control.name == "CommandButton1"), None)
    text_box_preview = Path("text-box-preview.png")
    button_preview = Path("button-preview.png")

    if text_box is None or button is None or text_box.properties is None or button.properties is None:
        print("The first slide must contain both named controls with editable properties.")
    elif not text_box_preview.is_file() or not button_preview.is_file():
        print("Supply both preview images before updating the controls.")
    else:
        text_box.properties.remove("Value")
        text_box.properties.add("Value", "Changed text")
        button.properties.remove("Caption")
        button.properties.add("Caption", "Show message")

        for control, preview in [(text_box, text_box_preview), (button, button_preview)]:
            image_data = preview.read_bytes()
            control.substitute_picture_format.picture.image = presentation.images.add_image(image_data)

        for control in controls:
            frame = control.frame
            control.frame = slides.ShapeFrame(frame.x, frame.y + 100, frame.width, frame.height, frame.flip_h, frame.flip_v, frame.rotation)

        presentation.save("edited-controls.pptm", slides.export.SaveFormat.PPTM)
        controls.clear()
        presentation.save("removed-controls.pptm", slides.export.SaveFormat.PPTM)
```

## **ActiveX Medya Oynatıcı Denetimi Ekle**

Yapılandırılmış bir Windows Media Player denetimini yeniden kullanmak için, ilk slaytında `WindowsMediaPlayer1` adlı bir oynatıcı bulunan bir şablonla başlayın. [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) tüm slaytı yeni bir sunuma kopyalar. Örnek, oynatıcının `URL` değerini [özellikler koleksiyonu](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) içinde ayarlar ve kopyalanan slaytı çıktıda tek slayt olarak kaydeder. Video harici kalır, bu yüzden oynatma sırasında oynatıcının erişebileceği bir yol seçin.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as template, slides.Presentation() as presentation:
    slide = presentation.slides.add_clone(template.slides[0])
    player = next((control for control in slide.controls if control.name == "WindowsMediaPlayer1"), None)

    if player is None or player.properties is None:
        print("The template slide must contain a named media player with editable properties.")
    else:
        player.properties.remove("URL")
        player.properties.add("URL", "Wildlife.mp4")
        presentation.slides.remove_at(0)
        presentation.save("linked-video.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Aspose.Slides ActiveX denetimlerini çalıştırmadan koruyabilir mi?**

Evet. Aspose.Slides, denetimlerin özellikleri ve konumları dahil olmak üzere, onları etkinleştirmeden okuyabilir ve kaydedebilir.

**ActiveX denetimleri OLE nesnelerinden nasıl farklıdır?**

ActiveX denetimleri, kullanıcıların bir slayt ile etkileşime girmesini sağlar; örneğin metin girişi yapabilir veya bir düğmeye tıklayabilir. Bir [OLE nesnesi](/slides/tr/python-net/manage-ole/) ise bir slaytın başka bir uygulama tarafından yönetilen içeriği (örneğin bir Excel çalışma sayfası) içermesine veya ona bağlanmasına izin verir.

**Aspose.Slides ile bir sunumu kaydettikten sonra ActiveX olayları VBA makrolarını tetiklemeye devam edecek mi?**

Sunumu PPTM gibi makro‑etkin bir formatta kaydederek VBA projesini koruyun. Windows için PowerPoint, güvenlik ayarları hem ActiveX denetimlerine hem de makrolara izin verdiğinde mevcut olay işleyicilerini çalıştırabilir.