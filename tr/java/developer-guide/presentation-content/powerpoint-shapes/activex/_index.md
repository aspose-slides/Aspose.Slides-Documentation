---
title: Java'da Sunumlarda ActiveX Denetimlerini Yönetme
linktitle: ActiveX
type: docs
weight: 80
url: /tr/java/activex/
keywords:
- ActiveX
- ActiveX denetimi
- ActiveX yönetimi
- ActiveX ekle
- ActiveX değiştir
- medya oynatıcı
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "ActiveX metin kutularını ve düğmelerini düzenleyin, denetim önizlemelerini güncelleyin ve Aspose.Slides for Java ile PowerPoint sunumlarında bir Windows Media Player denetimini yeniden kullanın."
---
## **Giriş**

ActiveX denetimleri bir PowerPoint slaytına metin kutuları, komut düğmeleri ve medya oynatıcıları gibi etkileşimli öğeler ekler. Aspose.Slides for Java bir slaydın denetimlerini [IBaseSlide.getControls](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getControls--) aracılığıyla sunar. Bu koleksiyonu bir denetimi düzenlemek, slaytta taşımak veya kaldırmak için kullanın.

## **ActiveX Denetimlerini ve Depolanan Özelliklerini Listeleme**

Bilinmeyen bir şablonu incelemek için onu okuma modunda açın ve her slayttaki denetimlerde döngü yapın. Örnek, slayt numarasını, denetim adını, [getClassId](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getClassId--) ve [getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--) içindeki her anahtar‑değer çiftini raporlar. Sunumu, denetimleri etkinleştirmeden, olayları veya makroları çalıştırmadan, değerleri değiştirmeden veya dosyayı kaydetmeden okur.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    for (int i = 0; i < presentation.getSlides().size(); i++) {
        for (IControl control : presentation.getSlides().get_Item(i).getControls()) {
            System.out.printf("Slide %d | %s | %s%n", i + 1, control.getName(), control.getClassId());
            IControlPropertiesCollection properties = control.getProperties();
            if (properties == null) {
                System.out.println("  Properties unavailable");
                continue;
            }
            if (properties.getCount() == 0) {
                System.out.println("  []");
            }
            for (String name : properties.getNamesOfProperties()) {
                System.out.printf("  %s = %s%n", name, properties.get_Item(name));
            }
        }
    }
} finally {
    presentation.dispose();
}
```

`ActiveX.pptm` içinden seçilen çıktı bir metin kutusu ve bir komut düğmesi gösterir.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Boş bir özellik koleksiyonu `[]` olarak görünür. İkili depolama kullanan denetimler için [getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--) `null` dönebilir; bu durumda `Properties unavailable` gösterilir. Yalnızca adlara ihtiyacınız varsa, null kontrolünden sonra [getNamesOfProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/#getNamesOfProperties--) kullanın. Rapor, sunumdan elde edilen mevcut özellikleri listeler. Bir denetim çalışma zamanında ek özellikler destekleyebilir.

## **ActiveX Denetimlerini Değiştir**

Örnek, ilk slaytta `TextBox1` adlı bir metin kutusu ve `CommandButton1` adlı bir komut düğmesi içeren makro‑etkin bir sunum bekler. Metin kutusu değerini ve düğme başlığını değiştirmek için [control properties collection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/) kullanır. Her denetimin, etkinleştirilmeden önce PowerPoint’in gösterebileceği statik bir önizlemesi de vardır. Güncellenmiş metin ve görünümü gösteren bir PNG sağlayın. Örnek bu görselleri [IControl.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getSubstitutePictureFormat--) aracılığıyla atar.

Örnek, ilk slayttaki her denetimin çerçevesini [IControl.setFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#setFrame-com.aspose.slides.IShapeFrame-) ile 100 puan aşağı kaydırır. Düzenlenmiş sunumu PPTM formatında kaydeder, ardından [IControlCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolcollection/#clear--) kullanarak o slayttan tüm ActiveX denetimlerini kaldırıp ikinci bir kopya oluşturur.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    IControlCollection controls = presentation.getSlides().get_Item(0).getControls();
    IControl textBox = null;
    IControl button = null;
    for (IControl control : controls) {
        if ("TextBox1".equals(control.getName())) {
            textBox = control;
        } else if ("CommandButton1".equals(control.getName())) {
            button = control;
        }
    }
    if (textBox == null || button == null || textBox.getProperties() == null || button.getProperties() == null) {
        System.out.println("The first slide must contain both named controls with editable properties.");
        return;
    }

    Path textBoxPath = Paths.get("text-box-preview.png");
    Path buttonPath = Paths.get("button-preview.png");
    byte[] textBoxBytes = Files.readAllBytes(textBoxPath);
    byte[] buttonBytes = Files.readAllBytes(buttonPath);
    IPPImage textBoxPreview = presentation.getImages().addImage(textBoxBytes);
    IPPImage buttonPreview = presentation.getImages().addImage(buttonBytes);
    textBox.getProperties().set_Item("Value", "Changed text");
    button.getProperties().set_Item("Caption", "Show message");
    textBox.getSubstitutePictureFormat().getPicture().setImage(textBoxPreview);
    button.getSubstitutePictureFormat().getPicture().setImage(buttonPreview);

    for (IControl control : controls) {
        IShapeFrame frame = control.getFrame();
        ShapeFrame moved = new ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation());
        control.setFrame(moved);
    }
    presentation.save("edited-controls.pptm", SaveFormat.Pptm);

    controls.clear();
    presentation.save("removed-controls.pptm", SaveFormat.Pptm);
} catch (IOException e) {
    System.out.println("Could not read a control preview: " + e.getMessage());
} finally {
    presentation.dispose();
}
```

## **ActiveX Medya Oynatıcı Denetimi Ekle**

Yapılandırılmış bir Windows Media Player denetimini yeniden kullanmak için, ilk slaytında `WindowsMediaPlayer1` adlı bir oynatıcı bulunan bir şablonla başlayın. [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) tüm slaytı yeni bir sunuma kopyalar. Örnek, oynatıcının `URL` değerini [properties collection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/) içinde ayarlar ve klonlanmış slaytı çıktının tek slaytı olarak kaydeder. Video harici kalır; bu nedenle oynatıcının oynatma sırasında erişebileceği bir yol seçin.

```java
import com.aspose.slides.*;

Presentation template = new Presentation("template.pptx");
try {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().addClone(template.getSlides().get_Item(0));
        IControl player = null;
        for (IControl control : slide.getControls()) {
            if ("WindowsMediaPlayer1".equals(control.getName())) {
                player = control;
                break;
            }
        }
        if (player == null || player.getProperties() == null) {
            System.out.println("The template slide must contain a named media player with editable properties.");
            return;
        }
        player.getProperties().set_Item("URL", "Wildlife.mp4");
        
        presentation.getSlides().removeAt(0);
        presentation.save("linked-video.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    template.dispose();
}
```

## **FAQ**

**Aspose.Slides ActiveX denetimlerini çalıştırmadan koruyabilir mi?**

Evet. Aspose.Slides, denetimleri, özellikleri ve konumlarıyla birlikte, onları etkinleştirmeden okuyabilir ve kaydedebilir.

**ActiveX denetimleri OLE nesnelerinden nasıl farklıdır?**

ActiveX denetimleri, kullanıcının bir slaytla etkileşime girmesini sağlar; örneğin metin girerek veya bir düğmeye tıklayarak. Bir [OLE nesnesi](/slides/tr/java/manage-ole/) ise bir slaydın başka bir uygulama tarafından yönetilen içeriği (ör. bir Excel çalışma sayfası) barındırmasına veya ona bağlanmasına izin verir.

**Aspose.Slides ile bir sunumu kaydettikten sonra ActiveX olayları VBA makrolarını tetiklemeye devam edecek mi?**

Sunumu VBA projesini korumak için PPTM gibi bir makro‑etkin formatta kaydedin. Windows için PowerPoint, güvenlik ayarları hem ActiveX denetimlerine hem de makrolara izin verdiğinde mevcut olay işleyicilerini çalıştırabilir.