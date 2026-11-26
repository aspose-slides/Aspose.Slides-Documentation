---
title: PHP kullanarak Sunumlarda ActiveX Kontrollerini Yönetme
linktitle: ActiveX
type: docs
weight: 80
url: /tr/php-java/activex/
keywords:
- ActiveX
- ActiveX denetimi
- ActiveX yönetimi
- ActiveX ekleme
- ActiveX düzenleme
- medya oynatıcı
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile PowerPoint sunumlarında ActiveX metin kutularını ve düğmelerini düzenleyin, kontrol önizlemelerini güncelleyin ve bir Windows Media Player kontrolünü yeniden kullanın."
---
## **Giriş**

ActiveX denetimleri, bir PowerPoint slaytına metin kutuları, komut düğmeleri ve medya oynatıcıları gibi etkileşimli öğeler ekler. Aspose.Slides for PHP via Java, bir slaydın denetimlerini [BaseSlide::getControls](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getControls) aracılığıyla ortaya çıkarır. Bu koleksiyonu bir denetimi düzenlemek, slayt üzerinde taşımak veya kaldırmak için kullanın.

## **ActiveX Kontrollerini ve Saklanan Özelliklerini Listeleme**

Bilinmeyen bir şablonu incelemek için, şablonu okuma modunda açın ve her slayttaki denetimlerin üzerinden döngüyle geçin. Örnek, slayt numarasını, denetim adını, [getClassId](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getClassId), ve [getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties) içindeki her anahtar‑değer çiftini raporlar. Sunumu, denetimleri etkinleştirmeden, olayları veya makroları çalıştırmadan, değerleri değiştirmeden veya dosyayı kaydetmeden okur.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("ActiveX.pptm");
try {
    $slides = $presentation->getSlides();
    for ($i = 0; $i < java_values($slides->size()); $i++) {
        $controls = $slides->get_Item($i)->getControls();
        for ($j = 0; $j < java_values($controls->size()); $j++) {
            $control = $controls->get_Item($j);
            printf("Slide %d | %s | %s\n", $i + 1, $control->getName(), $control->getClassId());
            $properties = $control->getProperties();
            if (java_is_null($properties)) {
                echo "  Properties unavailable\n";
                continue;
            }
            if (java_values($properties->getCount()) === 0) {
                echo "  []\n";
                continue;
            }
            $names = $properties->getNamesOfProperties()->iterator();
            while (java_values($names->hasNext())) {
                $name = $names->next();
                printf("  %s = %s\n", $name, $properties->get_Item($name));
            }
        }
    }
} finally {
    $presentation->dispose();
}
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

Boş bir özellik koleksiyonu `[]` olarak görünür. İkili depolama kullanan denetimler için [getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties) `null` döndürebilir; bu durum `Properties unavailable` olarak gösterilir. Yalnızca adlara ihtiyacınız varsa, null kontrolünden sonra [getNamesOfProperties](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) kullanın. Rapor, sunumdan elde edilen özellikleri listeler. Bir denetim, çalışma zamanında ek özellikleri destekleyebilir.

## **ActiveX Kontrollerini Değiştirme**

Örnek, ilk slaytta `TextBox1` adında bir metin kutusu ve `CommandButton1` adında bir komut düğmesi içeren, makro etkin bir sunum bekler. Metin kutusu değerini ve düğme başlığını değiştirmek için [denetim özellikleri koleksiyonu](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/) kullanır. Her denetimin, PowerPoint'in etkinleştirmeden önce gösterebileceği statik bir önizlemesi de vardır. Güncellenmiş metin ve görünümünü gösteren bir PNG sağlayın. Örnek, bu görüntüleri [Control::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getSubstitutePictureFormat) aracılığıyla atar.

Örnek, ilk slayttaki tüm denetimleri çerçevesini [Control::setFrame](https://reference.aspose.com/slides/php-java/aspose.slides/control/#setFrame) ile ayarlayarak 100 puan aşağı kaydırır. Düzenlenmiş sunumu PPTM formatında kaydeder, ardından [ControlCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/#clear) kullanarak o slayttan tüm ActiveX denetimlerini kaldırılmış ikinci bir kopya kaydeder.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeFrame;

$presentation = new Presentation("ActiveX.pptm");
try {
    $controls = $presentation->getSlides()->get_Item(0)->getControls();
    $textBox = null;
    $button = null;
    for ($j = 0; $j < java_values($controls->size()); $j++) {
        $control = $controls->get_Item($j);
        $name = (string) $control->getName();
        if ($name === "TextBox1") {
            $textBox = $control;
        } elseif ($name === "CommandButton1") {
            $button = $control;
        }
    }
    if ($textBox === null || $button === null || java_is_null($textBox->getProperties()) || java_is_null($button->getProperties())) {
        echo "The first slide must contain both named controls with editable properties.\n";
        return;
    }

    foreach ([[$textBox, "text-box-preview.png"], [$button, "button-preview.png"]] as [$control, $path]) {
        $image = Images::fromFile($path);
        try {
            $preview = $presentation->getImages()->addImage($image);
            $control->getSubstitutePictureFormat()->getPicture()->setImage($preview);
        } finally {
            $image->dispose();
        }
    }
    $textBox->getProperties()->set_Item("Value", "Changed text");
    $button->getProperties()->set_Item("Caption", "Show message");

    for ($j = 0; $j < java_values($controls->size()); $j++) {
        $control = $controls->get_Item($j);
        $frame = $control->getFrame();
        $newY = java_values($frame->getY()) + 100;
        $moved = new ShapeFrame($frame->getX(), $newY, $frame->getWidth(), $frame->getHeight(), $frame->getFlipH(), $frame->getFlipV(), $frame->getRotation());
        $control->setFrame($moved);
    }
    $presentation->save("edited-controls.pptm", SaveFormat::Pptm);

    $controls->clear();
    $presentation->save("removed-controls.pptm", SaveFormat::Pptm);
} finally {
    $presentation->dispose();
}
```
## **ActiveX Medya Oynatıcı Kontrolü Ekleme**

Yapılandırılmış bir Windows Media Player kontrolünü yeniden kullanmak için, ilk slaytında `WindowsMediaPlayer1` adında bir oynatıcı bulunan bir şablonla başlayın. [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addClone) tüm slaytı yeni bir sunuma kopyalar. Örnek, oynatıcının `URL` özelliğini [özellikler koleksiyonu](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/) içinde ayarlar ve kopyalanan slaytı çıktıda tek slayt olarak kaydeder. Video harici kalır, bu yüzden oynatma sırasında oynatıcının erişebileceği bir yol seçin.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$template = new Presentation("template.pptx");
try {
    $presentation = new Presentation();
    try {
        $slides = $presentation->getSlides();
        $sourceSlide = $template->getSlides()->get_Item(0);
        $slide = $slides->addClone($sourceSlide);
        $player = null;
        $controls = $slide->getControls();
        for ($j = 0; $j < java_values($controls->size()); $j++) {
            $control = $controls->get_Item($j);
            if ((string) $control->getName() === "WindowsMediaPlayer1") {
                $player = $control;
                break;
            }
        }
        if ($player === null || java_is_null($player->getProperties())) {
            echo "The template slide must contain a named media player with editable properties.\n";
            return;
        }
        $player->getProperties()->set_Item("URL", "Wildlife.mp4");
        $slides->removeAt(0);
        $presentation->save("linked-video.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $template->dispose();
}
```
## **SSS**

**Aspose.Slides ActiveX denetimlerini çalıştırmadan koruyabilir mi?**  
Evet. Aspose.Slides, denetimlerin özellikleri ve konumları dahil olmak üzere, denetimleri etkinleştirmeden okuyabilir ve kaydedebilir.

**ActiveX denetimleri OLE nesnelerinden nasıl farklıdır?**  
ActiveX denetimleri, kullanıcıların bir slaytla etkileşimde bulunmasını sağlar; örneğin metin girişi yapabilir veya bir düğmeye tıklayabilir. Bir [OLE nesnesi](/slides/tr/php-java/manage-ole/) bir slaytın başka bir uygulama tarafından yönetilen içeriği (örneğin bir Excel çalışma sayfası) barındırmasına veya ona bağlanmasına izin verir.

**ActiveX olayları, Aspose.Slides ile bir sunumu kaydettikten sonra VBA makrolarını tetiklemeye devam eder mi?**  
Sunumu, VBA projesini korumak için PPTM gibi bir makro etkin formatta kaydedin. Windows için PowerPoint, güvenlik ayarları hem ActiveX denetimlerine hem de makrolara izin verdiğinde mevcut olay işleyicilerini çalıştırabilir.