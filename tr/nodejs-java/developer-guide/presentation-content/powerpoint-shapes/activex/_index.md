---
title: Sunumlarda JavaScript Kullanarak ActiveX Denetimlerini Yönetme
linktitle: ActiveX
type: docs
weight: 80
url: /tr/nodejs-java/activex/
keywords:
- ActiveX
- ActiveX denetimi
- ActiveX yönetimi
- ActiveX ekleme
- ActiveX değiştirme
- medya oynatıcı
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java'in ActiveX'i nasıl kullandığını öğrenin; PowerPoint sunumlarını otomatikleştirir ve geliştirir, geliştiricilere slaytlar üzerinde güçlü kontrol sağlar."
---
## **Giriş**

ActiveX denetimleri sunumlarda kullanılır. Aspose.Slides for Node.js via Java, ActiveX denetimlerini eklemenize ve yönetmenize olanak tanır, ancak normal sunum şekillerine kıyasla yönetimi biraz daha zordur. Aspose.Slides içinde Media Player Active denetimini ekleme desteği geliştirdik. ActiveX denetimlerinin şekil olmadığını; sunumun [ShapeCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapecollection/) parçası olmadığını unutmayın. Bunun yerine ayrı bir [ControlCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/controlcollection/) parçasıdırlar. Bu konuda, onlarla nasıl çalışılacağını göstereceğiz.

## **Slayta Media Player ActiveX Denetimi Ekleme**
ActiveX Media Player denetimini eklemek için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfının örneğini oluşturun ve boş bir sunum örneği üretin.  
2. Hedef slayta, [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) içinde erişin.  
3. Media Player ActiveX denetimini, [ControlCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/controlcollection/) tarafından sunulan [addControl](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ControlCollection#addControl-int-float-float-float-float-) yöntemiyle ekleyin.  
4. Media Player ActiveX denetimine erişin ve özelliklerini kullanarak video yolunu ayarlayın.  
5. Sunumu PPTX dosyası olarak kaydedin.

Yukarıdaki adımlara dayalı bu örnek kod, bir slayta Media Player ActiveX Denetimi nasıl ekleyeceğinizi gösterir:

```javascript
// Boş sunum örneği oluştur
var pres = new aspose.slides.Presentation();
try {
    // Media Player ActiveX denetimini ekleme
    pres.getSlides().get_Item(0).getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 100, 100, 400, 400);
    // Media Player ActiveX denetimine eriş ve video yolunu ayarla
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("java.net.URL", "Wildlife.wmv");
    // Sunumu kaydet
    pres.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ActiveX Denetimini Değiştirme**
Bir slayttaki metin kutusu ve basit komut düğmesi gibi basit bir ActiveX denetimini yönetmek için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfının örneğini oluşturun ve içinde ActiveX denetimleri bulunan sunumu yükleyin.  
2. Dizinini kullanarak bir slayt başvurusunu alın.  
3. Slayttaki ActiveX denetimlerine, [ControlCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/controlcollection/) aracılığıyla erişin.  
4. TextBox1 ActiveX denetimine [Control](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/control/) nesnesiyle erişin.  
5. TextBox1 ActiveX denetiminin metin, yazı tipi, yazı tipi yüksekliği ve çerçeve konumu gibi özelliklerini değiştirin.  
6. CommandButton1 adlı ikinci erişim denetimine erişin.  
7. Düğme başlığını, yazı tipini ve konumunu değiştirin.  
8. ActiveX denetim çerçevelerinin konumunu kaydırın.  
9. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

Yukarıdaki adımlara dayalı bu örnek kod, basit bir ActiveX denetimini nasıl yöneteceğinizi gösterir:

```javascript
// ActiveX denetimlerine sahip sunuma erişim
var pres = new aspose.slides.Presentation("ActiveX.pptm");
try {
    // Sunumdaki ilk slayta erişim
    var slide = pres.getSlides().get_Item(0);
    // TextBox metnini değiştirme
    var control = slide.getControls().get_Item(0);
    if (control.getName().toUpperCase() === "TextBox1".toUpperCase() && (control.getProperties() != null)) {
        var newText = "Changed text";
        control.getProperties().set_Item("Value", newText);
        // Yerine geçecek resmi değiştir. PowerPoint, ActiveX etkinleştirilmesi sırasında bu resmi değiştirecek,
        // bu yüzden bazen resmi değiştirilmemiş bırakmak sorun olmaz.
        var image = java.newInstanceSync("java.awt.image.BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
        var graphics = image.getGraphics();
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "window"));
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
        var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "windowText"));
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlShadow"));
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlDkShadow"));
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlHighlight"));
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlLtHighlight"));
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
        graphics.dispose();
        var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
        imageio.write(image, "PNG", baos);
        var byteStream = Readable.from([Buffer.from(baos.toByteArray())]);
        aspose.slides.readBytesFromStream(byteStream, (imgData) => {
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(imgData));
        });
    }
    // Düğme başlığını değiştirme
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);
    if (control.getName().toUpperCase() === "CommandButton1".toUpperCase() && (control.getProperties() != null)) {
        var newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // Yerine geçen resmi değiştir
        var image = java.newInstanceSync("java.awt.image.BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
        var graphics = image.getGraphics();
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "control"));
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
        var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "windowText"));
        graphics.setFont(font);
        var metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, java.newFloat((image.getWidth() - metrics.stringWidth(newCaption)) / 2), 20);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlLtHighlight"));
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlHighlight"));
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlShadow"));
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlDkShadow"));
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
        graphics.dispose();
        
        var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
        imageio.write(image, "PNG", baos);
        var byteStream = Readable.from([Buffer.from(baos.toByteArray())]);
        aspose.slides.readBytesFromStream(byteStream, (imgData) => {
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(imgData));
        });
    }
    // 100 puan aşağı kaydırma
    for (let i = 0; i < pres.getSlides().get_Item(0).getControls().size(); i++) {
        let ctl = pres.getSlides().get_Item(0).getControls().get_Item(i);
        var frame = ctl.getFrame();
        ctl.setFrame(new aspose.slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), java.newByte(frame.getFlipH()), java.newByte(frame.getFlipV()), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", aspose.slides.SaveFormat.Pptm);
    // denetimleri kaldırma
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", aspose.slides.SaveFormat.Pptm);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**Aspose.Slides, Python çalışma zamanında çalıştırılamıyorsa ActiveX denetimlerini okurken ve yeniden kaydederken korur mu?**  
Evet. Aspose.Slides bunları sunumun bir parçası olarak kabul eder ve özelliklerini ve çerçevelerini okuyup değiştirebilir; denetimlerin kendilerini çalıştırmak, onları korumak için gerekli değildir.

**ActiveX denetimleri bir sunumdaki OLE nesnelerinden nasıl farklıdır?**  
ActiveX denetimleri etkileşimli yönetilen denetimlerdir (düğmeler, metin kutuları, medya oynatıcı), oysa [OLE](/slides/tr/nodejs-java/manage-ole/) gömülü uygulama nesnelerini (örneğin bir Excel çalışma sayfası) ifade eder. Farklı şekilde depolanır ve işlenir ve farklı özellik modellerine sahiptir.

**Dosya Aspose.Slides tarafından değiştirildiyse ActiveX olayları ve VBA makroları çalışır mı?**  
Aspose.Slides mevcut işaretlemeyi ve meta verileri korur; ancak, olaylar ve makrolar yalnızca güvenlik izin verdiğinde Windows'ta PowerPoint içinde çalışır. Kütüphane VBA çalıştırmaz.