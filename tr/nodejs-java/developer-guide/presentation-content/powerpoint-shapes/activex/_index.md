---
title: JavaScript Kullanarak Sunularda ActiveX Denetimlerini Yönetme
linktitle: ActiveX
type: docs
weight: 80
url: /tr/nodejs-java/activex/
keywords:
- ActiveX
- ActiveX denetimi
- ActiveX yönetimi
- ActiveX ekleme
- ActiveX düzenleme
- medya oynatıcı
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java kullanarak PowerPoint sunumlarında ActiveX metin kutularını ve düğmelerini düzenleyin, denetim ön izlemelerini güncelleyin ve bir Windows Media Player denetimini yeniden kullanın."
---
## **Giriş**

ActiveX denetimleri, bir PowerPoint slaytına metin kutuları, komut düğmeleri ve medya oynatıcılar gibi etkileşimli öğeler ekler. Aspose.Slides for Node.js via Java, bir slaydın denetimlerini [BaseSlide.getControls](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getControls) aracılığıyla ortaya çıkarır. Bu koleksiyonu bir denetimi düzenlemek, slayt üzerindeki konumunu değiştirmek veya kaldırmak için kullanın.

## **ActiveX Denetimlerini ve Saklanan Özelliklerini Listeleme**

Tanıdık olmayan bir şablonu incelemek için, şablonu okuma modunda açın ve her slayttaki denetimler üzerinde yineleme yapın. Örnek, slayt numarasını, denetim adını, [getClassId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getClassId), ve [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties) içindeki her anahtar‑değer çiftini rapor eder. Sunumu, denetimleri etkinleştirmeden, olayları veya makroları tetiklemeden, değerleri değiştirmeden veya dosyayı kaydetmeden okur.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("ActiveX.pptm");
try {
    const slideList = presentation.getSlides();
    for (let i = 0; i < slideList.size(); i++) {
        const controls = slideList.get_Item(i).getControls();
        for (let j = 0; j < controls.size(); j++) {
            const control = controls.get_Item(j);
            console.log(`Slide ${i + 1} | ${control.getName()} | ${control.getClassId()}`);
            const properties = control.getProperties();
            if (properties == null) {
                console.log("  Properties unavailable");
                continue;
            }
            if (properties.getCount() === 0) {
                console.log("  []");
            }
            const names = properties.getNamesOfProperties().iterator();
            while (names.hasNext()) {
                const name = names.next();
                console.log(`  ${name} = ${properties.get_Item(name)}`);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Seçilen çıktı `ActiveX.pptm` dosyasından bir metin kutusu ve bir komut düğmesi gösterir.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

`[]` şeklinde boş bir özellik koleksiyonu görünür. İkili depolama kullanan denetimler için, [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties) `null` dönebilir ve bu `Properties unavailable` olarak gösterilir. Yalnızca adlara ihtiyacınız varsa, null kontrolünden sonra [getNamesOfProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) kullanın. Rapor, sunumda mevcut olan özellikleri listeler. Bir denetim çalışma zamanında ek özellikleri destekleyebilir.

## **ActiveX Denetimlerini Değiştirme**

Örnek, ilk slaytta `TextBox1` adlı bir metin kutusu ve `CommandButton1` adlı bir komut düğmesi içeren makro etkin bir sunum bekler. Metin kutusu değerini ve düğme başlığını değiştirmek için [control properties collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) kullanır. Her denetimin ayrıca PowerPoint'in etkinleştirmeden önce görüntüleyebileceği statik bir ön izlemesi vardır. Güncellenmiş metin ve görünümü gösteren bir PNG sağlayın. Örnek bu görüntüleri [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getSubstitutePictureFormat) aracılığıyla atar.

Örnek, birinci slayttaki tüm denetimleri çerçevelerini [Control.setFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#setFrame) ile ayarlayarak 100 puan aşağı kaydırır. Düzenlenmiş sunumu PPTM formatında kaydeder, ardından [ControlCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/#clear) kullanarak o slayttan tüm ActiveX denetimlerini kaldırılmış ikinci bir kopya kaydeder.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function addPreview(presentation, path) {
    const image = slides.Images.fromFile(path);
    try {
        return presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
}

function editControls() {
    const presentation = new slides.Presentation("ActiveX.pptm");
    try {
        const controls = presentation.getSlides().get_Item(0).getControls();
        let textBox;
        let button;
        for (let i = 0; i < controls.size(); i++) {
            const control = controls.get_Item(i);
            if (control.getName() === "TextBox1") {
                textBox = control;
            } else if (control.getName() === "CommandButton1") {
                button = control;
            }
        }
        if (!textBox || !button || textBox.getProperties() == null || button.getProperties() == null) {
            console.log("The first slide must contain both named controls with editable properties.");
            return;
        }

        const textBoxPreview = addPreview(presentation, "text-box-preview.png");
        const buttonPreview = addPreview(presentation, "button-preview.png");
        textBox.getProperties().set_Item("Value", "Changed text");
        button.getProperties().set_Item("Caption", "Show message");
        textBox.getSubstitutePictureFormat().getPicture().setImage(textBoxPreview);
        button.getSubstitutePictureFormat().getPicture().setImage(buttonPreview);

        for (let i = 0; i < controls.size(); i++) {
            const control = controls.get_Item(i);
            const frame = control.getFrame();
            const flipH = java.newByte(frame.getFlipH());
            const flipV = java.newByte(frame.getFlipV());
            const moved = new slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), flipH, flipV, frame.getRotation());
            control.setFrame(moved);
        }
        presentation.save("edited-controls.pptm", slides.SaveFormat.Pptm);

        controls.clear();
        presentation.save("removed-controls.pptm", slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}

editControls();
```
## **ActiveX Medya Oynatıcı Denetimi Ekleme**

Yapılandırılmış bir Windows Media Player denetimini yeniden kullanmak için, ilk slaytında `WindowsMediaPlayer1` adlı bir oynatıcı bulunan bir şablonla başlayın. [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addClone) tüm slaytı yeni bir sunuma kopyalar. Örnek, oynatıcının `URL` değerini [properties collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) içinde ayarlar ve kopyalanan slaytı çıktıda tek slayt olarak kaydeder. Video harici kalır, bu yüzden oynatma sırasında oynatıcının erişebileceği bir yol seçin.

```javascript
const slides = require("aspose.slides.via.java");

function addMediaPlayer() {
    const template = new slides.Presentation("template.pptx");
    try {
        const presentation = new slides.Presentation();
        try {
            const templateSlide = template.getSlides().get_Item(0);
            const slide = presentation.getSlides().addClone(templateSlide);
            const controls = slide.getControls();
            let player;
            for (let i = 0; i < controls.size(); i++) {
                const control = controls.get_Item(i);
                if (control.getName() === "WindowsMediaPlayer1") {
                    player = control;
                    break;
                }
            }
            if (!player || player.getProperties() == null) {
                console.log("The template slide must contain a named media player with editable properties.");
                return;
            }
            player.getProperties().set_Item("URL", "Wildlife.mp4");
            
            presentation.getSlides().removeAt(0);
            presentation.save("linked-video.pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        template.dispose();
    }
}

addMediaPlayer();
```
## **SSS**

**Aspose.Slides ActiveX denetimlerini çalıştırmadan koruyabilir mi?**

Evet. Aspose.Slides, denetimleri, özellikleri ve konumları dahil olmak üzere, etkinleştirmeden okuyabilir ve kaydedebilir.

**ActiveX denetimleri OLE nesnelerinden nasıl farklıdır?**

ActiveX denetimleri, kullanıcıların bir slaytla etkileşime girmesini sağlar; örneğin metin girişi yapabilir veya bir düğmeye tıklayabilir. Bir [OLE nesnesi](/slides/tr/nodejs-java/manage-ole/) bir slaydın başka bir uygulama tarafından yönetilen içeriği, örneğin bir Excel çalışma sayfasını içermesine veya ona bağlanmasına izin verir.

**Aspose.Slides ile bir sunumu kaydettikten sonra ActiveX olayları VBA makrolarını tetiklemeye devam eder mi?**

Sunumu, VBA projesini korumak için PPTM gibi makro etkin bir biçimde kaydedin. Windows için PowerPoint, güvenlik ayarları hem ActiveX denetimlerine hem de makrolara izin verdiğinde mevcut olay işleyicilerini çalıştırabilir.