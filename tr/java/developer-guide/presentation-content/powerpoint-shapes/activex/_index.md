---
title: Java Kullanarak Sunumlarda ActiveX Denetimlerini Yönetme
linktitle: ActiveX
type: docs
weight: 80
url: /tr/java/activex/
keywords:
- ActiveX
- ActiveX denetimi
- ActiveX yönetimi
- ActiveX ekleme
- ActiveX değiştirme
- medya oynatıcı
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'ın ActiveX'i kullanarak PowerPoint sunumlarını otomatikleştirip geliştirdiğini, geliştiricilere slaytlar üzerinde güçlü kontrol sağlayan özellikleri öğrenin."
---
## **Giriş**

ActiveX denetimleri sunumlarda kullanılır. Aspose.Slides for Java, ActiveX denetimlerini eklemenize ve yönetmenize olanak tanır, ancak bunlar normal sunum şekilleriyle karşılaştırıldığında yönetimi biraz daha zordur. Aspose.Slides içinde Media Player Active denetimi ekleme desteği uyguladık. ActiveX denetimlerinin şekil olmadığını; sunumun [IShapeCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapecollection/) parçası olmadığını unutmayın. Bunun yerine ayrı bir [IControlCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icontrolcollection/) içinde bulunurlar. Bu konuda, onlarla nasıl çalışılacağını göstereceğiz. 

## **Bir Slayda Media Player ActiveX Denetimi Ekleme**
ActiveX Media Player denetimi eklemek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun ve boş bir sunum örneği oluşturun.
1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) içinde hedef slayta erişin.
1. [IControlCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icontrolcollection/) tarafından sunulan [addControl](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) yöntemini kullanarak Media Player ActiveX denetimini ekleyin.
1. Media Player ActiveX denetimine erişin ve özelliklerini kullanarak video yolunu ayarlayın.
1. Sunumu PPTX dosyası olarak kaydedin.

Yukarıdaki adımlara dayanan bu örnek kod, bir slayta Media Player ActiveX Denetimi nasıl eklenir gösterir:

```java
import com.aspose.slides.*;

// Boş sunum örneği oluştur
Presentation pres = new Presentation();
try {
    // Media Player ActiveX denetimini ekleme
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Media Player ActiveX denetimine eriş ve video yolunu ayarla
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // Sunumu kaydet
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ActiveX Denetimini Değiştirme**
{{% alert color="info" %}} 

Aspose.Slides for Java 7.1.0 ve sonraki sürümler, ActiveX denetimlerini yönetmek için bileşenlerle donatılmıştır. Sunumunuzda zaten eklenmiş bir ActiveX denetimine erişebilir ve özellikleri aracılığıyla değiştirebilir veya silebilirsiniz.

{{% /alert %}} 

Bir slaytta metin kutusu ve basit bir komut düğmesi gibi basit bir ActiveX denetimini yönetmek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun ve içinde ActiveX denetimleri bulunan sunumu yükleyin.
1. Slayt referansını indeksine göre alın.
1. Slayttaki ActiveX denetimlerine, [IControlCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icontrolcollection/) üzerinden erişin.
1. [IControl](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icontrol/) nesnesini kullanarak TextBox1 ActiveX denetimine erişin.
1. TextBox1 ActiveX denetiminin metin, yazı tipi, yazı tipi yüksekliği ve çerçeve konumu gibi özelliklerini değiştirin.
1. CommandButton1 adlı ikinci denetime erişin.
1. Düğme başlığını, yazı tipini ve konumunu değiştirin.
1. ActiveX denetim çerçevelerinin konumunu kaydırın.
1. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

Yukarıdaki adımlara dayanan bu örnek kod, basit bir ActiveX denetiminin nasıl yönetileceğini gösterir: 

```java
import com.aspose.slides.*;
import java.awt.FontMetrics;
import java.awt.SystemColor;
import java.awt.image.BufferedImage;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import javax.imageio.ImageIO;

// ActiveX denetimleriyle sunuma erişim
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // Sunumdaki ilk slayta erişim
    ISlide slide = pres.getSlides().get_Item(0);

    // TextBox metnini değiştirme
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // Yerine geçen resmi değiştiriyor. PowerPoint, activeX etkinleştirilirken bu resmi değiştirecek,
        // bu yüzden bazen resmin değiştirilmemiş bırakılması sorun olmayabilir.
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);

        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.window);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlDkShadow);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

        graphics.dispose();

        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        ImageIO.write(image, "PNG", baos);

        control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
    }

    // Düğme başlığını değiştiriyor
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);

    if (control.getName().equalsIgnoreCase("CommandButton1") && control.getProperties() != null) {
        String newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // Yerine geçen öğeyi değiştiriyor
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);
        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.control);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        FontMetrics metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, (image.getWidth() - metrics.stringWidth(newCaption)) / 2, 20);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlDkShadow);
                graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
                graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

                graphics.dispose();

                ByteArrayOutputStream baos = new ByteArrayOutputStream();
                ImageIO.write(image, "PNG", baos);

                control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
            }

            // 100 puan aşağı kaydırılıyor
            for (IControl ctl : pres.getSlides().get_Item(0).getControls()) {
                IShapeFrame frame = ctl.getFrame();
                ctl.setFrame(new ShapeFrame(frame.getX(), frame.getY() + 100,
                        frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
            }
            pres.save("withActiveX-edited_java.pptm", SaveFormat.Pptm);

            // Denetimler kaldırılıyor
            pres.getSlides().get_Item(0).getControls().clear();
            pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
        } catch(IOException e) {
        } finally {
            if (pres != null) pres.dispose();
        }
```

## **SSS**

### Aspose.Slides, Java çalışma zamanında çalıştırılamayan ActiveX denetimlerini okurken ve yeniden kaydederken korur mu?

Evet. Aspose.Slides, bunları sunumun bir parçası olarak kabul eder ve özelliklerini ve çerçevelerini okuyup değiştirebilir; denetimlerin kendisinin çalıştırılması korunmaları için gerekli değildir.

### ActiveX denetimleri, bir sunumdaki OLE nesnelerinden nasıl farklıdır?

ActiveX denetimleri, (düğmeler, metin kutuları, medya oynatıcı) gibi etkileşimli yönetilen denetimlerdir, whereas [OLE](/slides/tr/java/manage-ole/) gömülü uygulama nesnelerini (örneğin bir Excel çalışma sayfası) ifade eder. Farklı şekilde depolanır ve işlenir ve farklı özellik modellerine sahiptir.

### Dosya Aspose.Slides tarafından değiştirilmişse ActiveX olayları ve VBA makroları çalışır mı?

Aspose.Slides mevcut işaretlemeyi ve meta verileri korur; ancak olaylar ve makrolar, güvenlik izin verdiğinde Windows üzerindeki PowerPoint içinde çalışır. Kütüphane VBA'yı çalıştırmaz.