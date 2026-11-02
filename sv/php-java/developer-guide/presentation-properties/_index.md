---
title: Hantera presentationsegenskaper i PHP
linktitle: Presentationsegenskaper
type: docs
weight: 70
url: /sv/php-java/presentation-properties/
keywords:
- PowerPoint-egenskaper
- presentationsegenskaper
- dokumentegenskaper
- inbyggda egenskaper
- anpassade egenskaper
- avancerade egenskaper
- hantera egenskaper
- modifiera egenskaper
- dokumentmetadata
- redigera metadata
- korrekturläsningsspråk
- standardspråk
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Behärska presentationsegenskaper i Aspose.Slides för PHP via Java och effektivisera sökning, varumärkesprofilering och arbetsflöde i dina PowerPoint- och OpenDocument-filer."
---
## **Introduktion**

Aspose.Slides för PHP via Java stöder **inbyggda** och **anpassade** dokumentegenskaper. Använd dessa egenskaper för att läsa och uppdatera presentationsmetadata, såsom författare, titel och användardefinierade värden.

Aspose.Slides låter dig arbeta med presentationsdokumentegenskaper via klassen [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) . En instans av denna klass returneras av [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/). Följande exempel visar hur man läser, ändrar och hanterar dessa egenskaper. De förutsätter att PHP/Java Bridge och Aspose.Slides PHP‑omslaget är initierade.

{{% alert color="info" title="Note" %}}
Aspose.Slides hanterar program‑ och producentmetadata när presentationer sparas; dessa fält identifierar den programvara som skapade utdata.
{{% /alert %}}

## **Hantera presentationsegenskaper**

Dokumentegenskaper lagrar beskrivande information tillsammans med presentationsinnehåll. De delas in i två kategorier:

- **Inbyggda egenskaper** innehåller standardmetadata, såsom titel, författare och dokumentstatistik.
- **Anpassade egenskaper** lagrar användardefinierade namn/värde‑par.

Aspose.Slides för PHP via Java ger åtkomst till båda kategorierna. I PowerPoint, välj **File → Info → Properties → Advanced Properties** för att inspektera dokumentmetadata. Dialogrutan grupperar information i flikar såsom **Summary**, **Statistics**, **Contents** och **Custom**. Använd fliken **Custom** för att hantera användardefinierade egenskaper.

## **Läsa offentliga egenskaper från en krypterad presentation**

Ett öppningslösenord skyddar normalt både presentationsinnehåll och dokumentegenskaper. När en presentation krypteras efter att ha anropat [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/setencryptdocumentproperties/) med `false`, förblir dess dokumentegenskaper offentliga. En applikation kan då anropa [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) med `true` och läsa den offentliga metadata utan att ange öppningslösenordet.

[LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) styr vad Aspose.Slides laddar; den avkrypterar ingenting. Om egenskaperna inkluderades i krypteringen misslyckas laddning utan lösenordet. Om presentationen inte är krypterad ignoreras alternativet och hela presentationen laddas.

Exemplet kräver en krypterad presentation vars dokumentegenskaper lämnades offentliga. Det verifierar laddningsläget via [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isonlydocumentpropertiesloaded/) och läser sedan inbyggda egenskaper via [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/):

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $documentProperties = $presentation->getDocumentProperties();

        echo("Author: " . $documentProperties->getAuthor() . "\n");
        echo("Title: " . $documentProperties->getTitle() . "\n");
        echo("Keywords: " . $documentProperties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode." . "\n");
    }
} finally {
    $presentation->dispose();
}
```

I detta läge laddas inte bildinnehåll. Bilder, masterbilder, layout, former, media och andra presentationsobjekt är otillgängliga. Applikationer bör alltid kontrollera [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isonlydocumentpropertiesloaded/) innan de utför en operation som kräver hela presentationsobjektmodellen.

{{% alert color="warning" title="Warning" %}}
Offentlig metadata kan avslöja författarnamn, titlar, ämnen, nyckelord, företagsinformation, kommentarer och anpassade värden. Kryptera känsliga egenskaper tillsammans med presentationen. Lämna dem offentliga endast när indexering, klassificering, sökning eller dokumenthanteringssystem har ett specifikt krav på att komma åt dem utan lösenord.
{{% /alert %}}

## **Uppdatera egenskaper för en krypterad presentation**

För en krypterad PPTX‑fil är en presentation som laddas efter att ha anropat [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) med `true` avsedd för att läsa offentlig metadata. Aspose.Slides kan inte spara ändrade egenskaper från det enbart metadata‑objektet eftersom de offentliga egenskaperna måste vara konsistenta med motsvarande data i den krypterade presentationen. Uppdatering av dem kräver därför korrekt öppningslösenord och en fullständig laddning.

Exemplet kräver en krypterad PPTX‑presentation med offentliga dokumentegenskaper och ett känt öppningslösenord. Det öppnar hela presentationen med [LoadOptions::setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setpassword/), uppdaterar offentliga inbyggda egenskaper och sparar resultatet. Därefter använder det [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/isencrypted/) för att verifiera att krypteringen bevaras och öppnar den offentliga metadata igen utan lösenord för att verifiera de nya värdena:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;
use aspose\slides\SaveFormat;

$inputPath = "public-properties-encrypted.pptx";
$outputPath = "updated-public-properties-encrypted.pptx";

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation($inputPath, $loadOptions);
try {
    $documentProperties = $presentation->getDocumentProperties();
    $documentProperties->setTitle("Updated Product Roadmap");
    $documentProperties->setKeywords("roadmap, planning, indexed");
    
    $presentation->save($outputPath, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($outputPath);
echo("The presentation is encrypted: " . (java_values($presentationInfo->isEncrypted()) ? "true" : "false") . "\n");

$metadataLoadOptions = new LoadOptions();
$metadataLoadOptions->setOnlyLoadDocumentProperties(true);

$metadataPresentation = new Presentation($outputPath, $metadataLoadOptions);
try {
    if (java_values($metadataPresentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        echo("Title: " . $metadataPresentation->getDocumentProperties()->getTitle() . "\n");
        echo("Keywords: " . $metadataPresentation->getDocumentProperties()->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode." . "\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

Om en applikation inte har tillåtelse att avkryptera eller ladda presentationsinnehållet måste den behandla offentliga egenskaper för en krypterad PPTX‑fil som skrivskyddade.

## **Åtkomst till inbyggda egenskaper**

Klassen [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) visar inbyggd metadata via getter‑metoder, inklusive [getAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getauthor/), [getTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/gettitle/) och [getCreatedTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcreatedtime/). Detta exempel öppnar en befintlig presentation och skriver ut dess lagrade metadata till konsolen. Värdena beror på indatapresentationen; vissa fält kan vara tomma.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("AccessBuiltInProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    echo("Category: " . $documentProperties->getCategory() . "\n");
    echo("Content status: " . $documentProperties->getContentStatus() . "\n");
    echo("Creation date: " . $documentProperties->getCreatedTime() . "\n");
    echo("Author: " . $documentProperties->getAuthor() . "\n");
    echo("Comments: " . $documentProperties->getComments() . "\n");
    echo("Keywords: " . $documentProperties->getKeywords() . "\n");
    echo("Last modified by: " . $documentProperties->getLastSavedBy() . "\n");
    echo("Manager: " . $documentProperties->getManager() . "\n");
    echo("Modified date: " . $documentProperties->getLastSavedTime() . "\n");
    echo("Presentation format: " . $documentProperties->getPresentationFormat() . "\n");
    echo("Last print date: " . $documentProperties->getLastPrinted() . "\n");
    echo("Is shared between producers: " . (java_values($documentProperties->getSharedDoc()) ? "true" : "false") . "\n");
    echo("Subject: " . $documentProperties->getSubject() . "\n");
    echo("Title: " . $documentProperties->getTitle() . "\n");
} finally {
    $presentation->dispose();
}
```

## **Modifiera inbyggda egenskaper**

För att uppdatera inbyggd metadata, använd setter‑metoderna på objektet som returneras av [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/). Detta exempel öppnar en befintlig presentation, anropar [setAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setauthor/), [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/settitle/), [setSubject](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setsubject/), [setComments](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setcomments/) och [setManager](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setmanager/), och sparar sedan den uppdaterade presentationen med [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/). Den sparade PPTX‑filen innehåller den nya metadata.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    $documentProperties->setAuthor("Aspose.Slides for PHP via Java");
    $documentProperties->setTitle("Manage PowerPoint Presentation Properties");
    $documentProperties->setSubject("Modify Built-in Properties");
    $documentProperties->setComments("Aspose description");
    $documentProperties->setManager("Aspose manager");

    $presentation->save("DocumentProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Hantera hyperlänkbasen**

[DocumentProperties::getHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/gethyperlinkbase/) returnerar dokumentnivåbasen för relativa hyperlänkar. Använd [DocumentProperties::setHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/sethyperlinkbase/) för att ändra eller rensa den. Detta är användbart när en presentation och dess länkade filer flyttas till en annan plats. Det är separat från en individuell hyperlänks [Hyperlink::getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getexternalurl/): att ändra basen omskriver inte de lagrade ländadresserna eller ändrar absoluta destinationer.

Exemplet kräver en presentation som innehåller både en relativ länk, t.ex. `target.html`, och en absolut länk, t.ex. `https://example.org/absolute.html`. Det läser den befintliga basen, tilldelar en ny basadress och sparar samt öppnar presentationen igen för att kontrollera värdet. Därefter rensar det basen med en tom sträng och verifierar det tomma värdet i en separat sparad fil. Ersätt den exempelbasadress som används med platsen för dina länkade filer.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("hyperlinks.pptx");
try {
    echo("Original base: " . $presentation->getDocumentProperties()->getHyperlinkBase() . "\n");

    $newBase = "https://example.com/new/";
    $presentation->getDocumentProperties()->setHyperlinkBase($newBase);
    $presentation->save("hyperlinks-updated.pptx", SaveFormat::Pptx);

    $updatedPresentation = new Presentation("hyperlinks-updated.pptx");
    try {
        echo("Base preserved: " . ((string) $updatedPresentation->getDocumentProperties()->getHyperlinkBase() === $newBase ? "true" : "false") . "\n");

        $updatedPresentation->getDocumentProperties()->setHyperlinkBase("");
        $updatedPresentation->save("hyperlinks-cleared.pptx", SaveFormat::Pptx);

        $clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
        try {
            echo("Base cleared: " . ((string) $clearedPresentation->getDocumentProperties()->getHyperlinkBase() === "" ? "true" : "false") . "\n");
        } finally {
            $clearedPresentation->dispose();
        }
    } finally {
        $updatedPresentation->dispose();
    }
} finally {
    $presentation->dispose();
}
```

De två verifieringsmeddelandena ska skriva ut `true`. Att rensa basen lämnar de individuella hyperlänkadresserna intakta.

En relativ länk till `target.pptx` öppnade `old/target.pptx` när basen pekade på mappen `old`. Efter att ha ändrat basen till mappen `new`, sparat och öppnat presentationen igen, öppnade samma länk `new/target.pptx`. En absolut länk fortsatte att öppna samma fil. Testa dina relativa länkar i PowerPoint före och efter att du flyttar presentationen eller ändrar dess bas.

## **Lägg till anpassade presentationsegenskaper**

Anpassade egenskaper lagrar metadata som saknar motsvarande inbyggt fält. Metoden [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/set_item/) låter dig tilldela ett värde enligt egenskapsnamn. Detta exempel skapar en presentation, lägger till två textvärden och ett heltalsversionsvärde, och sparar presentationen med [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/). Att tilldela ett värde till ett befintligt namn ersätter den egenskapens värde.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $documentProperties = $presentation->getDocumentProperties();

    $documentProperties->set_Item("Reviewed by", "John Smith");
    $documentProperties->set_Item("Confidentiality level", "Internal");
    $documentProperties->set_Item("Document version", 2);

    $presentation->save("CustomDocumentProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Åtkomst och modifiering av anpassade egenskaper**

Detta exempel öppnar en presentation som innehåller anpassade egenskaper och använder [getCountOfCustomProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcountofcustomproperties/) för att iterera över dem. [getCustomPropertyName](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcustompropertyname/) accepterar ett nollbaserat index och returnerar namnet som används av [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/set_item/). Exemplet skriver ut varje ursprungligt namn och värde, ersätter varje värde med en numrerad sträng oavsett dess ursprungliga typ, och sparar ändringarna. Om det inte finns några anpassade egenskaper gör loopen inga förändringar.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AccessAndModifyProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    for ($i = 0; $i < java_values($documentProperties->getCountOfCustomProperties()); $i++) {
        $propertyName = $documentProperties->getCustomPropertyName($i);
        $propertyValue = $documentProperties->get_Item($propertyName);

        echo("Custom property name: " . $propertyName . "\n");
        echo("Custom property value: " . $propertyValue . "\n");

        $documentProperties->set_Item($propertyName, "New Value " . ($i + 1));
    }

    $presentation->save("CustomProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Live‑exempel**

Prova den online‑appen [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) för att se hur du arbetar med dokumentegenskaper med Aspose.Slides‑‑API:n:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Hur kan jag ta bort en inbyggd egenskap från en presentation?**

Inbyggda egenskaper är en integrerad del av presentationen och kan inte tas bort helt. Du kan dock ändra deras värden eller sätta dem till tomma om den specifika egenskapen tillåter det.

**Vad händer om jag lägger till en anpassad egenskap som redan finns?**

Om du lägger till en anpassad egenskap som redan finns, kommer dess befintliga värde att skrivas över med det nya. Du behöver inte ta bort eller kontrollera egenskapen i förväg, eftersom Aspose.Slides automatiskt uppdaterar egenskapens värde.

**Kan jag komma åt presentationsegenskaper utan att ladda hela presentationen?**

Ja. Använd [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/getpresentationinfo/) och sedan [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/readdocumentproperties/) för att läsa lagrad dokumentmetadata utan att skapa en [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑instans. Se [Build a Lightweight Presentation Inventory](/slides/sv/php-java/examine-presentation/) för ett komplett rapportexempel och format‑specifika begränsningar.

**Kan jag läsa offentliga egenskaper i en krypterad presentation utan dess öppningslösenord?**

Ja. Presentationen måste ha krypterats efter att ha anropat [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/setencryptdocumentproperties/) med `false`, och den måste laddas efter att ha anropat [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) med `true`.

**Kan jag uppdatera en krypterad PPTX‑fil i endast‑dokument‑egenskaper‑läge?**

Nej. Offentliga och krypterade egenskapsdata måste förbli konsistenta, så uppdatering av en krypterad PPTX‑fil kräver att hela presentationen laddas med korrekt öppningslösenord.