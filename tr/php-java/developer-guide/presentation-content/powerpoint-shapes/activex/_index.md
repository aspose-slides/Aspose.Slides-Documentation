---
title: PHP ile Sunumlarda ActiveX Denetimlerini Yönetme
linktitle: ActiveX
type: docs
weight: 80
url: /tr/php-java/activex/
keywords:
- ActiveX
- ActiveX denetimi
- ActiveX yönet
- ActiveX ekle
- ActiveX değiştir
- medya oynatıcı
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java'ın ActiveX'i nasıl kullandığını öğrenin; PowerPoint sunumlarını otomatikleştirir ve geliştirir, geliştiricilere slaytlar üzerinde güçlü kontrol sağlar."
---
## **Giriş**

ActiveX denetimleri sunumlarda kullanılır. Aspose.Slides for PHP via Java, ActiveX denetimlerini eklemenize ve yönetmenize olanak tanır, ancak bunlar normal sunum şekilleriyle karşılaştırıldığında yönetimi biraz daha zordur. Aspose.Slides içinde Media Player Active kontrolünün eklenmesi için destek sağladık. ActiveX denetimlerinin şekil olmadığını, sunumun [ShapeCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/) içinde yer almadığını unutmayın. Bunun yerine ayrı bir [ControlCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/controlcollection/) içindedirler. Bu konuda, onlarla nasıl çalışılacağını göstereceğiz.

## **Bir Slayta Media Player ActiveX Denetimi Eklemek**
Bir ActiveX Media Player denetimi eklemek için aşağıdakileri yapın:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun ve boş bir sunum örneği oluşturun.
2. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) içinde hedef slayta erişin.
3. Media Player ActiveX denetimini, [ControlCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/controlcollection/) tarafından sunulan [addControl](https://reference.aspose.com/slides/tr/php-java/aspose.slides/controlcollection/addcontrol/) yöntemini kullanarak ekleyin.
4. Media Player ActiveX denetimine erişin ve özelliklerini kullanarak video yolunu ayarlayın.
5. Sunumu PPTX dosyası olarak kaydedin.

Bu örnek kod, yukarıdaki adımlara dayanarak, bir slayta Media Player ActiveX Denetimi eklemeyi gösterir:

```php
  # Boş sunum örneği oluştur
  $pres = new Presentation();
  try {
    # Media Player ActiveX denetimini ekleme
    $pres->getSlides()->get_Item(0)->getControls()->addControl(ControlType::WindowsMediaPlayer, 100, 100, 400, 400);
    # Media Player ActiveX denetimine eriş ve video yolunu ayarla
    $pres->getSlides()->get_Item(0)->getControls()->get_Item(0)->getProperties()->set_Item("URL", "Wildlife.wmv");
    # Sunumu kaydet
    $pres->save("Output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ActiveX Denetimini Değiştirmek**
{{% alert color="primary" %}} 
Aspose.Slides for PHP via Java 7.1.0 ve daha yeni sürümler, ActiveX denetimlerini yönetmek için bileşenlerle donatılmıştır. Sunumunuzda zaten eklenmiş bir ActiveX denetimine erişebilir ve özellikleri aracılığıyla değiştirebilir veya silebilirsiniz.
{{% /alert %}} 

Bir slaytta metin kutusu ve basit bir komut düğmesi gibi basit bir ActiveX denetimini yönetmek için aşağıdakileri yapın:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun ve içinde ActiveX denetimleri bulunan sunumu yükleyin.
2. İndeksine göre bir slayt referansı alın.
3. Slayttaki ActiveX denetimlerine, [ControlCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/controlcollection/) erişerek ulaşın.
4. [Control](https://reference.aspose.com/slides/tr/php-java/aspose.slides/control/) nesnesini kullanarak TextBox1 ActiveX denetimine erişin.
5. TextBox1 ActiveX denetiminin metin, yazı tipi, yazı tipi yüksekliği ve çerçeve konumu gibi özelliklerini değiştirin.
6. CommandButton1 adlı ikinci denetime erişin.
7. Düğmenin başlığını, yazı tipini ve konumunu değiştirin.
8. ActiveX denetimlerinin çerçeve konumlarını kaydırın.
9. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

Bu örnek kod, yukarıdaki adımlara dayanarak, basit bir ActiveX denetimini nasıl yöneteceğinizi gösterir: 

```php
  # ActiveX denetimleri ile sunuma erişme
  $pres = new Presentation("ActiveX.pptm");
  try {
    # Sunumdaki ilk slayta erişme
    $slide = $pres->getSlides()->get_Item(0);
    # TextBox metnini değiştirme
    $control = $slide->getControls()->get_Item(0);
    if (!java_is_null($control->getName()->equalsIgnoreCase("TextBox1") && $control->getProperties())) {
      $newText = "Changed text";
      $control->getProperties()->set_Item("Value", $newText);
      # Yerine koyma resmini değiştiriyor. PowerPoint bu resmi ActiveX etkinleştirilirken değiştirecek,
      # bu yüzden bazen resmi değiştirmeden bırakmak OK'dur.
      $image = new BufferedImage($control->getFrame()->getWidth(), $control->getFrame()->getHeight(), BufferedImage->TYPE_INT_ARGB);
      $graphics = $image->getGraphics();
      $graphics->setColor(SystemColor->window);
      $graphics->fillRect(0, 0, $image->getWidth(), $image->getHeight());
      $font = new Font($control->getProperties()->get_Item("FontName"), Font->PLAIN, 16);
      $graphics->setColor(SystemColor->windowText);
      $graphics->setFont($font);
      $graphics->drawString($newText, 10, 20);
      $graphics->setColor(SystemColor->controlShadow);
      $graphics->drawLine(0, $image->getHeight() - 1, 0, 0);
      $graphics->drawLine(0, 0, $image->getWidth() - 1, 0);
      $graphics->setColor(SystemColor->controlDkShadow);
      $graphics->drawLine(1, $image->getHeight() - 2, 1, 1);
      $graphics->drawLine(1, 1, $image->getWidth() - 2, 1);
      $graphics->setColor(SystemColor->controlHighlight);
      $graphics->drawLine(1, $image->getHeight() - 1, $image->getWidth() - 1, $image->getHeight() - 1);
      $graphics->drawLine($image->getWidth() - 1, $image->getHeight() - 1, $image->getWidth() - 1, 1);
      $graphics->setColor(SystemColor->controlLtHighlight);
      $graphics->drawLine(0, $image->getHeight(), $image->getWidth(), $image->getHeight());
      $graphics->drawLine($image->getWidth(), $image->getHeight(), $image->getWidth(), 0);
      $graphics->dispose();
      $baos = new Java("java.io.ByteArrayOutputStream");
      Java("javax.imageio.ImageIO")->write($image, "PNG", $baos);
      $control->getSubstitutePictureFormat()->getPicture()->setImage($pres->getImages()->addImage($baos->toByteArray()));
    }
    # Düğme başlığını değiştiriyor
    $control = $pres->getSlides()->get_Item(0)->getControls()->get_Item(1);
    if (!java_is_null($control->getName()->equalsIgnoreCase("CommandButton1") && $control->getProperties())) {
      $newCaption = "Show MessageBox";
      $control->getProperties()->set_Item("Caption", $newCaption);
      # Yerine koyma resmini değiştir
      $image = new BufferedImage($control->getFrame()->getWidth(), $control->getFrame()->getHeight(), BufferedImage->TYPE_INT_ARGB);
      $graphics = $image->getGraphics();
      $graphics->setColor(SystemColor->control);
      $graphics->fillRect(0, 0, $image->getWidth(), $image->getHeight());
      $font = new Font($control->getProperties()->get_Item("FontName"), Font->PLAIN, 16);
      $graphics->setColor(SystemColor->windowText);
      $graphics->setFont($font);
      $metrics = $graphics->getFontMetrics($font);
      $graphics->drawString($newCaption, $image->getWidth() - $metrics->stringWidth($newCaption) / 2, 20);
      $graphics->setColor(SystemColor->controlLtHighlight);
      $graphics->drawLine(0, $image->getHeight() - 1, 0, 0);
      $graphics->drawLine(0, 0, $image->getWidth() - 1, 0);
      $graphics->setColor(SystemColor->controlHighlight);
      $graphics->drawLine(1, $image->getHeight() - 2, 1, 1);
      $graphics->drawLine(1, 1, $image->getWidth() - 2, 1);
      $graphics->setColor(SystemColor->controlShadow);
      $graphics->drawLine(1, $image->getHeight() - 1, $image->getWidth() - 1, $image->getHeight() - 1);
      $graphics->drawLine($image->getWidth() - 1, $image->getHeight() - 1, $image->getWidth() - 1, 1);
      $graphics->setColor(SystemColor->controlDkShadow);
      $graphics->drawLine(0, $image->getHeight(), $image->getWidth(), $image->getHeight());
      $graphics->drawLine($image->getWidth(), $image->getHeight(), $image->getWidth(), 0);
      $graphics->dispose();
      $baos = new Java("java.io.ByteArrayOutputStream");
      Java("javax.imageio.ImageIO")->write($image, "PNG", $baos);
      $control->getSubstitutePictureFormat()->getPicture()->setImage($pres->getImages()->addImage($baos->toByteArray()));
    }
    # 100 puan aşağı kaydırma
    foreach($pres->getSlides()->get_Item(0)->getControls() as $ctl) {
      $frame = $ctl->getFrame();
      $ctl->setFrame(new ShapeFrame($frame->getX(), $frame->getY() + 100, $frame->getWidth(), $frame->getHeight(), $frame->getFlipH(), $frame->getFlipV(), $frame->getRotation()));
    }
    $pres->save("withActiveX-edited_java.pptm", SaveFormat::Pptm);
    # denetimleri kaldırma
    $pres->getSlides()->get_Item(0)->getControls()->clear();
    $pres->save("withActiveX-cleared_java.pptm", SaveFormat::Pptm);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**Aspose.Slides, Java çalışma zamanında çalıştırılamadığında ActiveX denetimlerini okurken ve yeniden kaydederken korur mu?**  
Evet. Aspose.Slides, bunları sunumun bir parçası olarak kabul eder ve özelliklerini ve çerçevelerini okuyabilir/değiştirebilir; denetimlerin kendilerini çalıştırmak, onları korumak için gerekli değildir.

**ActiveX denetimleri, bir sunumdaki OLE nesnelerinden nasıl farklıdır?**  
ActiveX denetimleri, etkileşimli yönetilen denetimlerdir (düğmeler, metin kutuları, medya oynatıcı), oysa [OLE](/slides/tr/php-java/manage-ole/) gömülü uygulama nesnelerini (örneğin bir Excel çalışma sayfası) ifade eder. Bunlar farklı şekilde depolanır ve işlenir ve farklı özellik modellerine sahiptir.

**Aspose.Slides tarafından dosya değiştirilmişse ActiveX olayları ve VBA makroları çalışır mı?**  
Aspose.Slides mevcut işaretlemeyi ve meta verileri korur; ancak olaylar ve makrolar, güvenlik izin verdiğinde yalnızca Windows üzerindeki PowerPoint içinde çalışır. Kütüphane VBA'yı çalıştırmaz.