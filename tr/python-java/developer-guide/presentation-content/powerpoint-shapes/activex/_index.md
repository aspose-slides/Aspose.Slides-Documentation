---
title: Sunumlarda Python ile ActiveX Denetimlerini Yönetme
linktitle: ActiveX
type: docs
weight: 80
url: /tr/python-java/activex/
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
description: "Aspose.Slides for Python via Java'ın ActiveX kullanarak PowerPoint sunumlarını otomatikleştirme ve geliştirme, geliştiricilere slaytlar üzerinde güçlü kontrol sağlayan yollarını öğrenin."
---
## **Giriş**

ActiveX denetimleri sunumlarda kullanılır. Aspose.Slides for Python via Java, ActiveX denetimlerini eklemenize ve yönetmenize olanak tanır, ancak normal sunum şekilleriyle karşılaştırıldığında yönetimi biraz daha zordur. Aspose.Slides, Medya Oynatıcı ActiveX denetimlerinin eklenmesini destekler. ActiveX denetimlerinin şekil olmadığına dikkat edin; bunlar sunumun [ShapeCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/) kısmının bir parçası değildir. Bunun yerine ayrı bir [ControlCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/controlcollection/) bölümünün parçasıdır. Bu konuda, bunlarla nasıl çalışılacağını göstereceğiz.

## **Bir Slayta Medya Oynatıcı ActiveX Denetimi Ekleme**

Bir ActiveX Medya Oynatıcı denetimi eklemek için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının örneğini oluşturun ve boş bir sunum örneği oluşturun.  
2. Hedef slayta, [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) içinde erişin.  
3. [ControlCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/controlcollection/) tarafından sunulan [addControl](https://reference.aspose.com/slides/tr/python-java/aspose.slides/controlcollection/#addControl) metodunu kullanarak Medya Oynatıcı ActiveX denetimini ekleyin.  
4. Medya Oynatıcı ActiveX denetimine erişin ve özelliklerini kullanarak video yolunu ayarlayın.  
5. Sunumu PPTX dosyası olarak kaydedin.

Yukarıdaki adımlara dayanan bu örnek kod, bir slayta Medya Oynatıcı ActiveX denetimi eklemeyi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

# Boş bir sunum oluştur.
presentation = Presentation()
try:
    # Medya Oynatıcı ActiveX denetimini ekle.
    slide = presentation.getSlides().get_Item(0)
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400)

    # Video yolunu ayarla.
    control.getProperties().set_Item("URL", "Wildlife.wmv")

    # Sunumu kaydet.
    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ActiveX Denetimini Değiştirme**

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java, ActiveX denetimlerini yönetmek için bileşenler sağlar. Sunumunuzda zaten eklenmiş olan ActiveX denetimine erişebilir ve özellikleri aracılığıyla onu değiştirebilir veya silebilirsiniz.
{{% /alert %}}

Bir slaytta metin kutusu ve basit bir komut düğmesi gibi basit bir ActiveX denetimini yönetmek için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının örneğini oluşturun ve içinde ActiveX denetimleri bulunan sunumu yükleyin.  
2. İndeksine göre bir slayt referansı alın.  
3. Slayttaki ActiveX denetimlerine, [ControlCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/controlcollection/)’a erişerek ulaşın.  
4. [Control](https://reference.aspose.com/slides/tr/python-java/aspose.slides/control/) nesnesini kullanarak TextBox1 ActiveX denetimine erişin.  
5. Metin, yazı tipi, yazı tipi yüksekliği ve çerçeve konumunu içeren TextBox1 ActiveX denetiminin özelliklerini değiştirin.  
6. CommandButton1 adlı ikinci ActiveX denetimine erişin.  
7. Düğme başlığını, yazı tipini ve konumunu değiştirin.  
8. ActiveX denetimlerinin çerçeve konumlarını kaydırın.  
9. Değiştirilen sunumu bir PPTM dosyasına yazın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeFrame
from java.awt import Font, SystemColor
from java.awt.image import BufferedImage
from java.io import ByteArrayOutputStream
from javax.imageio import ImageIO

# ActiveX denetimlerini içeren sunumu yükle.
presentation = Presentation("ActiveX.pptm")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getControls().size() >= 2:
        # İlk slayta eriş.
        slide = presentation.getSlides().get_Item(0)

        # Metin kutusunun metnini değiştir.
        control = slide.getControls().get_Item(0)

        if str(control.getName()).lower() == "textbox1" and control.getProperties() is not None:
            new_text = "Changed text"
            control.getProperties().set_Item("Value", new_text)

            # Yedek resmi değiştir. PowerPoint, ActiveX etkinleştirilirken resmi değiştirir,
            # bu yüzden bazen değişmeden bırakılabilir.
            image = BufferedImage(int(control.getFrame().getWidth()), int(control.getFrame().getHeight()), BufferedImage.TYPE_INT_ARGB)

            graphics = image.getGraphics()
            graphics.setColor(SystemColor.window)
            graphics.fillRect(0, 0, image.getWidth(), image.getHeight())

            font = Font(control.getProperties().get_Item("FontName"), Font.PLAIN, 16)
            graphics.setColor(SystemColor.windowText)
            graphics.setFont(font)
            graphics.drawString(new_text, 10, 20)

            graphics.setColor(SystemColor.controlShadow)
            graphics.drawLine(0, image.getHeight() - 1, 0, 0)
            graphics.drawLine(0, 0, image.getWidth() - 1, 0)

            graphics.setColor(SystemColor.controlDkShadow)
            graphics.drawLine(1, image.getHeight() - 2, 1, 1)
            graphics.drawLine(1, 1, image.getWidth() - 2, 1)

            graphics.setColor(SystemColor.controlHighlight)
            graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1)
            graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1)

            graphics.setColor(SystemColor.controlLtHighlight)
            graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight())
            graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0)

            graphics.dispose()

            image_stream = ByteArrayOutputStream()
            ImageIO.write(image, "PNG", image_stream)

            image_bytes = image_stream.toByteArray()
            substitute_image = presentation.getImages().addImage(image_bytes)
            control.getSubstitutePictureFormat().getPicture().setImage(substitute_image)

        # Düğme başlığını değiştir.
        control = presentation.getSlides().get_Item(0).getControls().get_Item(1)

        if str(control.getName()).lower() == "commandbutton1" and control.getProperties() is not None:
            new_caption = "Show MessageBox"
            control.getProperties().set_Item("Caption", new_caption)
            # Yedek resmi değiştir.
            image = BufferedImage(int(control.getFrame().getWidth()), int(control.getFrame().getHeight()), BufferedImage.TYPE_INT_ARGB)
            graphics = image.getGraphics()
            graphics.setColor(SystemColor.control)
            graphics.fillRect(0, 0, image.getWidth(), image.getHeight())

            font = Font(control.getProperties().get_Item("FontName"), Font.PLAIN, 16)
            graphics.setColor(SystemColor.windowText)
            graphics.setFont(font)
            metrics = graphics.getFontMetrics(font)
            graphics.drawString(new_caption, (image.getWidth() - metrics.stringWidth(new_caption)) // 2, 20)

            graphics.setColor(SystemColor.controlLtHighlight)
            graphics.drawLine(0, image.getHeight() - 1, 0, 0)
            graphics.drawLine(0, 0, image.getWidth() - 1, 0)

            graphics.setColor(SystemColor.controlHighlight)
            graphics.drawLine(1, image.getHeight() - 2, 1, 1)
            graphics.drawLine(1, 1, image.getWidth() - 2, 1)

            graphics.setColor(SystemColor.controlShadow)
            graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1)
            graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1)

            graphics.setColor(SystemColor.controlDkShadow)
            graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight())
            graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0)

            graphics.dispose()

            image_stream = ByteArrayOutputStream()
            ImageIO.write(image, "PNG", image_stream)

            image_bytes = image_stream.toByteArray()
            substitute_image = presentation.getImages().addImage(image_bytes)
            control.getSubstitutePictureFormat().getPicture().setImage(substitute_image)

        # Denetimleri 100 puan aşağı kaydır.
        for control in slide.getControls():
            frame = control.getFrame()
            new_frame = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(new_frame)
        presentation.save("withActiveX-edited_python.pptm", SaveFormat.Pptm)

        # Denetimleri kaldır.
        presentation.getSlides().get_Item(0).getControls().clear()
        presentation.save("withActiveX-cleared_python.pptm", SaveFormat.Pptm)
    else:
        print("The first slide must contain the TextBox1 and CommandButton1 ActiveX controls.")
finally:
    presentation.dispose()
```

## **SSS**

**Aspose.Slides, Python çalışma zamanında çalıştırılamazsa, okuma ve yeniden kaydetme sırasında ActiveX denetimlerini korur mu?**  
**Evet. Aspose.Slides, bunları sunumun bir parçası olarak ele alır ve özelliklerini ve çerçevelerini okuyup/değiştirebilir; denetimlerin kendisini çalıştırmak, onları korumak için gerekli değildir.**

**ActiveX denetimleri, bir sunumdaki OLE nesnelerinden nasıl farklıdır?**  
ActiveX denetimleri, (düğmeler, metin kutuları, medya oynatıcı gibi) etkileşimli yönetilen denetimlerdir, oysa [OLE](/slides/tr/python-java/manage-ole/) gömülü uygulama nesnelerini (örneğin bir Excel çalışma sayfası) ifade eder. Bunlar farklı şekilde depolanır ve işlenir ve farklı özellik modellerine sahiptir.

**Dosya Aspose.Slides tarafından değiştirilmişse, ActiveX olayları ve VBA makroları çalışır mı?**  
Aspose.Slides mevcut işaretlemeyi ve meta verileri korur; ancak olaylar ve makrolar, güvenlik izin verdiğinde yalnızca Windows'taki PowerPoint içinde çalışır. Kütüphane VBA'yı çalıştırmaz.