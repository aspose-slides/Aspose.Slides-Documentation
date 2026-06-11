---
title: Hantera SmartArt-grafik i presentationer med PHP
linktitle: SmartArt-grafik
type: docs
weight: 20
url: /sv/php-java/manage-smartart-shape/
keywords:
- SmartArt-objekt
- SmartArt-grafik
- SmartArt-stil
- SmartArt-färg
- skapa SmartArt
- lägga till SmartArt
- redigera SmartArt
- ändra SmartArt
- åtkomst till SmartArt
- SmartArt layouttyp
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Automatisera skapande, redigering och formatering av PowerPoint SmartArt i PHP med Aspose.Slides, med korta kodexempel och prestandafokuserad vägledning."
---
## **Översikt**

Aspose.Slides låter dig skapa och hantera SmartArt-grafik i PowerPoint-presentationer programmässigt. Denna artikel förklarar hur du lägger till en SmartArt-form på en bild, får åtkomst till befintliga SmartArt-former, hittar SmartArt efter en specifik layouttyp och uppdaterar dess visuella utseende genom att ändra SmartArt-stilen eller färgstilen.

Exemplen visar hur du arbetar med SmartArt-former via bildens formsamling, kontrollerar om en form är SmartArt och sedan modifierar eller inspekterar dess egenskaper.

## **Skapa en SmartArt-form**
Aspose.Slides för PHP via Java har tillhandahållit ett API för att skapa SmartArt-former. För att skapa en SmartArt-form i en bild, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) .
2. Hämta referensen till en bild genom att använda dess index.
3. [Lägg till en SmartArt-form](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/#addSmartArt) genom att ställa in dess [LayoutType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SmartArtLayoutType) .
4. Spara den modifierade presentationen som en PPTX‑fil.

```php
  # Instansiera Presentation-klass
  $pres = new Presentation();
  try {
    # Hämta första bilden
    $slide = $pres->getSlides()->get_Item(0);
    # Lägg till SmartArt-form
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::BasicBlockList);
    # Sparar presentationen
    $pres->save("SimpleSmartArt.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figur: SmartArt-form tillagd på bilden**|

## **Åtkomst till en SmartArt-form på en bild**
Följande kod kommer att användas för att få åtkomst till SmartArt-formerna som lagts till i presentationsbilden. I exempelkoden kommer vi att gå igenom varje form i bilden och kontrollera om den är en [SmartArt](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SmartArt) form. Om formen är av typen SmartArt kommer vi att typkonvertera den till en [**SmartArt**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SmartArt) instans.

```php
  # Läs in den önskade presentationen
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Gå igenom varje form i den första bilden
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Kontrollera om formen är av typen SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Typkonvertera formen till SmartArtEx
        $smart = $shape;
        echo("Shape Name:" . $smart->getName());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Åtkomst till en SmartArt-form med en viss layouttyp**
Följande exempel kod hjälper till att få åtkomst till [SmartArt](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SmartArt) formen med en viss LayoutType. Observera att du inte kan ändra LayoutType för SmartArt eftersom den är skrivskyddad och endast sätts när [SmartArt](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SmartArt) formen läggs till.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) och ladda presentationen med SmartArt-form.
1. Hämta referensen till den första bilden genom att använda dess index.
1. Gå igenom varje form i den första bilden.
1. Kontrollera om formen är av typen [SmartArt](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SmartArt) och typkonvertera den valda formen till SmartArt om den är SmartArt.
1. Kontrollera SmartArt-formen med den specifika LayoutType och utför vad som krävs därefter.

```php
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Gå igenom varje form i den första bilden
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Kontrollera om formen är av typen SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Typkonvertera formen till SmartArtEx
        $smart = $shape;
        # Kontrollerar SmartArt-layout
        if ($smart->getLayout() == SmartArtLayoutType::BasicBlockList) {
          echo("Do some thing here....");
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ändra en SmartArt-forms stil**
I det här exemplet kommer vi att lära oss att ändra snabbstilen för en valfri SmartArt-form.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) och ladda presentationen med SmartArt-form.
1. Hämta referensen till den första bilden genom att använda dess index.
1. Gå igenom varje form i den första bilden.
1. Kontrollera om formen är av typen [SmartArt](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SmartArt) och typkonvertera den till SmartArt om den är SmartArt.
1. Hitta SmartArt-formen med en viss stil.
1. Ange den nya stilen för SmartArt-formen.
1. Spara presentationen.

```php
  # Instansiera Presentation-klass
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Hämta första bilden
    $slide = $pres->getSlides()->get_Item(0);
    # Gå igenom varje form i den första bilden
    foreach($slide->getShapes() as $shape) {
      # Kontrollera om formen är av typen SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Typkonvertera formen till SmartArtEx
        $smart = $shape;
        # Kontrollerar SmartArt-stil
        if ($smart->getQuickStyle() == SmartArtQuickStyleType::SimpleFill) {
          # Ändrar SmartArt-stil
          $smart->setQuickStyle(SmartArtQuickStyleType::Cartoon);
        }
      }
    }
    # Sparar presentationen
    $pres->save("ChangeSmartArtStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figur: SmartArt-form med ändrad stil**|

## **Ändra en SmartArt-forms färgstil**
I det här exemplet kommer vi att lära oss att ändra färgstilen för en valfri SmartArt-form. I följande exempel kod kommer vi att få åtkomst till SmartArt-formen med en specifik färgstil och ändra dess stil.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) och ladda presentationen med SmartArt-form.
1. Hämta referensen till den första bilden genom att använda dess index.
1. Gå igenom varje form i den första bilden.
1. Kontrollera om formen är av typen [SmartArt](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SmartArt) och typkonvertera den till SmartArt om den är SmartArt.
1. Hitta SmartArt-formen med en viss färgstil.
1. Ange den nya färgstilen för SmartArt-formen.
1. Spara presentationen.

```php
  # Instansiera Presentation-klass
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Hämta första bilden
    $slide = $pres->getSlides()->get_Item(0);
    # Gå igenom varje form i den första bilden
    foreach($slide->getShapes() as $shape) {
      # Kontrollera om formen är av typen SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Typkonvertera formen till SmartArtEx
        $smart = $shape;
        # Kontrollerar SmartArt-färgtyp
        if ($smart->getColorStyle() == SmartArtColorType::ColoredFillAccent1) {
          # Ändrar SmartArt-färgtyp
          $smart->setColorStyle(SmartArtColorType::ColorfulAccentColors);
        }
      }
    }
    # Sparar presentationen
    $pres->save("ChangeSmartArtColorStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figur: SmartArt-form med ändrad färgstil**|

## **Vanliga frågor**

**Kan jag animera SmartArt som ett enda objekt?**

Ja. SmartArt är en form, så du kan tillämpa [standardanimationer](/slides/sv/php-java/powerpoint-animation/) via animations-API:t (ingång, avslut, betoning, rörelsespår) precis som för andra former.

**Hur kan jag hitta en specifik SmartArt på en bild om jag inte känner till dess interna ID?**

Ange och använd alternativ text (AltText) och sök efter formen med det värdet – detta är ett rekommenderat sätt att lokalisera målformen.

**Kan jag gruppera SmartArt med andra former?**

Ja. Du kan gruppera SmartArt med andra former (bilder, tabeller etc.) och sedan [manipulera gruppen](/slides/sv/php-java/group/).

**Hur får jag en bild av en specifik SmartArt (t.ex. för en förhandsgranskning eller rapport)?**

Exportera en miniatyrbild/bild av formen; biblioteket kan [rendera enskilda former](/slides/sv/php-java/create-shape-thumbnails/) till rasterfiler (PNG/JPG/TIFF).

**Kommer SmartArts utseende att bevaras när hela presentationen konverteras till PDF?**

Ja. Renderingsmotorn strävar efter hög noggrannhet för [PDF-export](/slides/sv/php-java/convert-powerpoint-to-pdf/), med ett antal kvalitets- och kompatibilitetsalternativ.