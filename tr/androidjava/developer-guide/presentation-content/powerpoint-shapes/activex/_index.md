---
title: Android'de Sunumlarda ActiveX Denetimlerini Yönetme
linktitle: ActiveX
type: docs
weight: 80
url: /tr/androidjava/activex/
keywords:
- ActiveX
- ActiveX denetimi
- ActiveX yönetimi
- ActiveX ekleme
- ActiveX düzenleme
- medya oynatıcı
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java kullanarak PowerPoint sunumlarında ActiveX metin kutularını ve düğmelerini düzenleyin, denetim ön izlemelerini güncelleyin ve bir Windows Media Player denetimini yeniden kullanın."
---
## **Giriş**

ActiveX denetimleri, bir PowerPoint slaytına metin kutuları, komut düğmeleri ve medya oynatıcılar gibi etkileşimli öğeler ekler. Aspose.Slides for Android via Java, bir slaytın denetimlerine [IBaseSlide.getControls](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getControls--) aracılığıyla erişim sağlar. Bu koleksiyonu bir denetimi düzenlemek, slayt içinde taşımak veya kaldırmak için kullanın. Aşağıdaki örneklerde, Android uygulamanızın okuyabildiği dosya yollarını kullanın ve her çıkış sunumu için yazılabilir bir konum seçin.

## **ActiveX Denetimlerini ve Depolanan Özelliklerini Listeleme**

Tanımadığınız bir şablonu incelemek için onu okuma modunda açın ve her slayttaki denetimler üzerinde döngü kurun. Örnek, slayt numarasını, denetim adını, [getClassId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getClassId--) ve [getProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getProperties--) içinde bulunan her anahtar‑değer çiftini rapor eder. Sunumu denetimleri etkinleştirmeden, olayları veya makroları tetiklemeden, değerleri değiştirmeden ve dosyayı kaydetmeden okur.

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

`ActiveX.pptm` dosyasının seçilen çıktısı bir metin kutusu ve bir komut düğmesi gösterir.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Boş bir özellik koleksiyonu `[]` olarak görünür. İkili depolama kullanan denetimler için [getProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getProperties--) `null` dönebilir; bu durumda `Properties unavailable` (Özellikler mevcut değil) olarak gösterilir. Yalnızca adlar gerekiyor ise, `null` kontrolünden sonra [getNamesOfProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/#getNamesOfProperties--) kullanılabilir. Rapor, sunumdan elde edilen özellikleri listeler. Bir denetim çalışma zamanında ek özellikler de destekleyebilir.

## **ActiveX Denetimlerini Değiştirme**

Örnek, ilk slaytta `TextBox1` adında bir metin kutusu ve `CommandButton1` adında bir komut düğmesi bulunan makro etkin bir sunum bekler. [control properties collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/) aracılığıyla metin kutusunun değerini ve düğmenin başlığını değiştirir. Her denetimin, etkinleştirilmeden önce PowerPoint'in gösterebileceği statik bir ön izlemesi vardır. Güncellenmiş metin ve görünümü gösteren bir PNG sağlayın. Örnek bu görüntüleri [IControl.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getSubstitutePictureFormat--) üzerinden atar.

Örnek, ilk slayttaki tüm denetimleri [IControl.setFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#setFrame-com.aspose.slides.IShapeFrame-) ile çerçevesini ayarlayarak 100 nokta aşağı kaydırır. Düzenlenmiş sunumu PPTM formatında kaydeder, ardından [IControlCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolcollection/#clear--) kullanarak aynı slayttaki tüm ActiveX denetimlerini kaldırıp ikinci bir kopya oluşturur.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.FileInputStream;

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

    IPPImage textBoxPreview;
    IPPImage buttonPreview;
    try (FileInputStream textBoxStream = new FileInputStream("text-box-preview.png");
         FileInputStream buttonStream = new FileInputStream("button-preview.png")) {
        textBoxPreview = presentation.getImages().addImage(textBoxStream);
        buttonPreview = presentation.getImages().addImage(buttonStream);
    }
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

## **ActiveX Medya Oynatıcı Denetimi Ekleme**

Yapılandırılmış bir Windows Media Player denetimini yeniden kullanmak için, ilk slaytta `WindowsMediaPlayer1` adlı bir oynatıcı içeren bir şablonla başlayın. [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) tüm slaytı yeni bir sunuma kopyalar. Örnek, oynatıcının `URL` özelliğini [properties collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/) içinde ayarlar ve kopyalanan slaytı çıkışta tek slayt olarak kaydeder. Video dışarıda kalır; bu nedenle oynatıcı oynatma sırasında erişebileceği bir yol seçin.

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

## **SSS**

**Aspose.Slides ActiveX denetimlerini çalıştırmadan koruyabilir mi?**

Evet. Aspose.Slides, denetimlerin özellikleri ve konumları dahil olmak üzere, onları etkinleştirmeden okuyabilir ve kaydedebilir.

**ActiveX denetimleri ile OLE nesneleri arasındaki fark nedir?**

ActiveX denetimleri, kullanıcıların bir slaytta metin girmesi veya bir düğmeye tıklaması gibi etkileşimlerde bulunmasını sağlar. Bir [OLE object](/slides/tr/androidjava/manage-ole/) ise bir slaytın başka bir uygulama tarafından yönetilen içeriği (ör. bir Excel çalışma sayfası) içermesine veya ona bağlanmasına izin verir.

**ActiveX olayları, Aspose.Slides ile bir sunumu kaydettikten sonra VBA makrolarını tetiklemeye devam eder mi?**

Sunumu VBA projesini korumak için PPTM gibi makro etkin bir formatta kaydedin. Windows için PowerPoint, güvenlik ayarları ActiveX denetimlerine ve makrolara izin verdiğinde mevcut olay işleyicilerini çalıştırabilir.