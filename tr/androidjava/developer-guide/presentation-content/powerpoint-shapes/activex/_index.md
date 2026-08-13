---
title: Android'de Sunumlarda ActiveX Kontrollerini Yönetme
linktitle: ActiveX
type: docs
weight: 80
url: /tr/androidjava/activex/
keywords:
- ActiveX
- ActiveX denetimi
- ActiveX yönet
- ActiveX ekle
- ActiveX değiştir
- medya oynatıcı
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java, ActiveX'i kullanarak PowerPoint sunumlarını otomatikleştirmenizi ve geliştirmenizi sağlar; geliştiricilere slaytlar üzerinde güçlü kontrol imkanı sunar."
---
## **Giriş**

ActiveX denetimleri sunumlarda kullanılır. Aspose.Slides for Android via Java, ActiveX denetimlerini eklemenizi ve yönetmenizi sağlar, ancak bunlar normal sunum şekillerine göre yönetilmesi biraz daha zor olabilir. Aspose.Slides içinde Media Player Active denetimini ekleme desteği uyguladık. ActiveX denetimlerinin şekil olmadığını; sunumun [IShapeCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/) içerisinde bulunmadığını unutmayın. Bunun yerine ayrı bir [IControlCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icontrolcollection/) içinde yer alırlar. Bu bölümde, bu denetimlerle nasıl çalışılacağını göstereceğiz.

## **Bir Slayta Media Player ActiveX Denetimi Ekleme**
Media Player ActiveX denetimini eklemek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun ve boş bir sunum örneği oluşturun.  
2. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) içinde hedef slaytı alın.  
3. [IControlCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icontrolcollection/) tarafından sunulan [addControl](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) yöntemini kullanarak Media Player ActiveX denetimini ekleyin.  
4. Media Player ActiveX denetimine erişin ve özelliklerini kullanarak video yolunu ayarlayın.  
5. Sunumu PPTX dosyası olarak kaydedin.

Yukarıdaki adımlara dayanan bu örnek kod, bir slayta Media Player ActiveX denetimi nasıl eklenir gösterir:

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

Aspose.Slides for Android via Java 7.1.0 ve daha yeni sürümler, ActiveX denetimlerini yönetmek için bileşenlerle donatılmıştır. Sunumunuzda önceden eklenmiş bir ActiveX denetimine erişebilir ve özellikleri aracılığıyla bunu değiştirebilir veya silebilirsiniz.

{{% /alert %}} 

Bir slaytta metin kutusu ve basit bir komut düğmesi gibi basit bir ActiveX denetimini yönetmek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun ve içinde ActiveX denetimleri bulunan sunumu yükleyin.  
2. Slayta indeks üzerinden bir referans elde edin.  
3. Slayttaki ActiveX denetimlerine, [IControlCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icontrolcollection/) erişerek ulaşın.  
4. [IControl](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icontrol/) nesnesini kullanarak TextBox1 ActiveX denetimine erişin.  
5. TextBox1 ActiveX denetiminin metin, yazı tipi, yazı tipi yüksekliği ve çerçeve konumu gibi özelliklerini değiştirin.  
6. İkinci erişim denetimi olan CommandButton1'i alın.  
7. Düğme başlığını, yazı tipini ve konumunu değiştirin.  
8. ActiveX denetimlerinin çerçeve konumlarını kaydırın.  
9. Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Yukarıdaki adımlara dayanan bu örnek kod, basit bir ActiveX denetiminin nasıl yönetileceğini gösterir: 

```java
import com.aspose.slides.*;
import java.awt.FontMetrics;
import java.awt.SystemColor;
import java.awt.image.BufferedImage;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import javax.imageio.ImageIO;

// ActiveX denetimlerine sahip sunuma erişim
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // Sunumdaki ilk slayta erişim
    ISlide slide = pres.getSlides().get_Item(0);

    // TextBox metnini değiştirme
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // Yer tutucu resmi değiştiriyor. PowerPoint, activeX aktivasyonu sırasında bu resmi değiştirecek,
        // bu nedenle bazen resmi değiştirmeden bırakmak sorun olmayabilir.
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

        // Yer tutucuyu değiştiriyor
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

    // 100 puan aşağı kaydırma
    for (IControl ctl : pres.getSlides().get_Item(0).getControls()) {
        IShapeFrame frame = ctl.getFrame();
        ctl.setFrame(new ShapeFrame(frame.getX(), frame.getY() + 100,
                frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", SaveFormat.Pptm);

    // denetimleri kaldırma
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

### Aspose.Slides, Java çalışma zamanında yürütülemiyorsa ActiveX denetimlerini okurken ve yeniden kaydederken korur mu?

Evet. Aspose.Slides bu denetimleri sunumun bir parçası olarak kabul eder ve özelliklerini ve çerçevelerini okuyup değiştirebilir; denetimlerin kendisinin yürütülmesi, onları korumak için gerekli değildir.

### ActiveX denetimleri, bir sunumdaki OLE nesnelerinden nasıl farklıdır?

ActiveX denetimleri etkileşimli yönetilen denetimlerdir (düğmeler, metin kutuları, medya oynatıcı), oysa [OLE](/slides/tr/androidjava/manage-ole/) gömülü uygulama nesnelerini (örneğin bir Excel çalışma sayfası) ifade eder. Bunlar farklı şekilde depolanır ve işlenir ve farklı özellik modellerine sahiptir.

### Dosya Aspose.Slides tarafından değiştirildiğinde ActiveX olayları ve VBA makroları çalışır mı?

Aspose.Slides mevcut işaretlemeyi ve meta verileri korur; ancak olaylar ve makrolar yalnızca Windows'ta PowerPoint içinde, güvenlik izin veriyorsa çalışır. Kütüphane VBA'yı yürütmez.