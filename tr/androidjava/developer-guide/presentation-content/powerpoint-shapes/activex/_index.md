---
title: Android'de Sunumlarda ActiveX Kontrollerini Yönetme
linktitle: ActiveX
type: docs
weight: 80
url: /tr/androidjava/activex/
keywords:
- ActiveX
- ActiveX kontrol
- ActiveX yönet
- ActiveX ekle
- ActiveX değiştir
- medya oynatıcı
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java'ın ActiveX'i kullanarak PowerPoint sunumlarını otomatikleştirme ve iyileştirme yöntemlerini öğrenin; geliştiricilere slaytlar üzerinde güçlü kontrol sağlar."
---
## **Giriş**

ActiveX kontrolleri sunumlarda kullanılır. Aspose.Slides for Android via Java, ActiveX kontrolleri eklemenize ve yönetmenize olanak tanır, ancak bunlar normal sunum şekilleriyle karşılaştırıldığında yönetimi biraz daha zordur. Aspose.Slides içinde Media Player Active kontrolünün eklenmesi desteğini uyguladık. ActiveX kontrollerinin şekil olmadığını; sunumun [IShapeCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/) parçası olmadıklarını, bunun yerine ayrı bir [IControlCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icontrolcollection/) içinde yer aldıklarını unutmayın. Bu konuda, bunlarla nasıl çalışılacağını göstereceğiz.

## **Bir Slayta Media Player ActiveX Kontrolü Ekleme**
Media Player ActiveX kontrolü eklemek için şunları yapın:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının örneğini oluşturun ve boş bir sunum örneği üretin.  
2. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) içinde hedef slayta erişin.  
3. [IControlCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icontrolcollection/) tarafından sunulan [addControl](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) yöntemiyle Media Player ActiveX kontrolünü ekleyin.  
4. Media Player ActiveX kontrolüne erişin ve özelliklerini kullanarak video yolunu ayarlayın.  
5. Sunumu PPTX dosyası olarak kaydedin.  

Bu örnek kod, yukarıdaki adımlara dayanarak bir slayta Media Player ActiveX Kontrolü eklemeyi gösterir:

```java
// Boş bir sunum örneği oluştur
Presentation pres = new Presentation();
try {
    // Media Player ActiveX kontrolü ekleniyor
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Media Player ActiveX kontrolüne eriş ve video yolunu ayarla
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // Sunumu kaydet
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ActiveX Kontrolünü Değiştirme**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Java 7.1.0 ve sonraki sürümler, ActiveX kontrollerini yönetmek için bileşenlerle donatılmıştır. Sunumunuzda zaten eklenmiş bir ActiveX kontrolüne erişebilir ve özellikleri üzerinden değiştirebilir ya da silebilirsiniz. 

{{% /alert %}} 

Bir slayttaki metin kutusu ve basit bir komut düğmesi gibi basit bir ActiveX kontrolünü yönetmek için şunları yapın:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının örneğini oluşturun ve içinde ActiveX kontrolleri bulunan sunumu yükleyin.  
2. İndeksine göre bir slayt referansı edinin.  
3. Slayttaki ActiveX kontrollerine [IControlCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icontrolcollection/) üzerinden erişin.  
4. [IControl](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icontrol/) nesnesini kullanarak TextBox1 ActiveX kontrolüne erişin.  
5. Metin, font, font yüksekliği ve çerçeve konumunu içeren TextBox1 ActiveX kontrolünün özelliklerini değiştirin.  
6. CommandButton1 adlı ikinci erişim kontrolüne erişin.  
7. Düğme başlığını, fontunu ve konumunu değiştirin.  
8. ActiveX kontrol çerçevelerinin konumunu kaydırın.  
9. Değiştirilmiş sunumu PPTX dosyası olarak yazın.  

Bu örnek kod, yukarıdaki adımlara dayanarak basit bir ActiveX kontrolünün nasıl yönetileceğini gösterir: 

```java
// ActiveX kontrolleriyle sunuma erişme
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // Sunumdaki ilk slayta erişme
    ISlide slide = pres.getSlides().get_Item(0);

    // TextBox metnini değiştirme
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // Yerine geçen resmi değiştiriyor. PowerPoint, ActiveX etkinleştirilirken bu resmi değiştirecektir,
        // bu yüzden bazen resmi değişmeden bırakmak kabul edilebilir.
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

    // Düğme başlığını değiştirme
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);

    if (control.getName().equalsIgnoreCase("CommandButton1") && control.getProperties() != null) {
        String newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // Yerine geçen resmi değiştir
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

            // kontrolleri kaldırma
            pres.getSlides().get_Item(0).getControls().clear();
            pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
        } catch(IOException e) {
        } finally {
            if (pres != null) pres.dispose();
        }
```

## **SSS**

**Aspose.Slides, Java çalışma zamanı içinde çalıştırılamadıklarında bile ActiveX kontrollerini okurken ve yeniden kaydederken korur mu?**  

Evet. Aspose.Slides, bunları sunumun bir parçası olarak ele alır ve özelliklerini ve çerçevelerini okuyup değiştirebilir; kontrollerin kendisinin çalıştırılması korunmaları için gerekli değildir.

**ActiveX kontrolleri bir sunumdaki OLE nesnelerinden nasıl farklıdır?**  

ActiveX kontrolleri etkileşimli yönetilen kontrollerdir (düğmeler, metin kutuları, medya oynatıcı), oysa [OLE](/slides/tr/androidjava/manage-ole/) gömülü uygulama nesnelerini (örneğin bir Excel çalışma sayfası) ifade eder. Bunlar farklı şekilde depolanır ve işlenir ve farklı özellik modellerine sahiptir.

**Aspose.Slides tarafından dosya değiştirildiyse ActiveX olayları ve VBA makroları çalışır mı?**  

Aspose.Slides mevcut işaretlemeyi ve meta verileri korur; ancak olaylar ve makrolar yalnızca Windows üzerindeki PowerPoint içinde, güvenlik izin veriyorsa çalışır. Kütüphane VBA’yı çalıştırmaz.