---
title: Licensiering
type: docs
weight: 80
url: /sv/php-java/licensing/
keywords:
- licens
- tillfällig licens
- ange licens
- använd licens
- validera licens
- licensfil
- utvärderingsversion
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Tillämpa, hantera och felsöka licenser i Aspose.Slides för PHP via Java. Säkerställ oavbruten åtkomst till alla funktioner med vår steg-för-steg guide för licensiering."
---
## **Introduktion**

Ibland kan en praktisk metod behövas för de bästa utvärderingsresultaten. Av den anledningen erbjuder Aspose.Slides olika inköpsplaner samt ett kostnadsfritt prov och en 30‑dagars temporär licens för utvärdering.

{{% alert color="primary" %}}
Observera att det finns ett antal allmänna policyer och rutiner som vägleder dig i hur du utvärderar, licensierar korrekt och köper våra produkter. Du hittar dem i avsnittet ["Köppolicyer och FAQ"](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Utvärdera Aspose.Slides**
Du kan enkelt ladda ner Aspose.Slides för utvärdering. Utvärderingspaketet är identiskt med det köpta paketet. Utvärderingsversionen blir helt enkelt licensierad efter att du har lagt till några rader kod för att tillämpa licensen. 

## **Begränsningar i utvärderingsversionen**
Utvärderingsversionen av Aspose.Slides (utan angiven licens) ger hela produktens funktionalitet, men den lägger in ett utvärderingsvattenmärke högst upp i dokumentet vid öppning och sparning. Du är också begränsad till en bild när du extraherar text från presentationsbilder.

{{% alert color="primary" %}} 
Om du vill testa Aspose.Slides utan begränsningarna i utvärderingsversionen kan du begära en **30‑dagars temporär licens**. Se [Hur får jag en temporär licens?](https://purchase.aspose.com/temporary-license) för mer information.
{{% /alert %}} 

## **Om licensen**
Du kan enkelt ladda ner en utvärderingsversion av Aspose.Slides för PHP via Java från dess [nedladdningssida](https://packagist.org/packages/aspose/slides). Utvärderingsversionen ger absolut **samma funktioner** som den licensierade versionen av Aspose.Slides. Dessutom blir utvärderingsversionen licensierad efter att du köpt en licens och lagt till ett par kodrader för att tillämpa licensen.

Licensen är en ren text‑XML‑fil som innehåller detaljer såsom produktnamn, antal utvecklare den är licensierad för, abonnemangets utgångsdatum med mera. Filen är digitalt signerad, så den får inte ändras. Även ett oavsiktligt extra radbrytning i filens innehåll gör den ogiltig.

För att undvika begränsningarna som är förknippade med utvärderingsversionen måste du ange en licens innan du använder **Aspose.Slides**. Du behöver bara ange licensen en gång per applikation eller process.

{{% alert color="primary" %}} 
Du kanske vill se [Mätlicensiering](https://docs.aspose.com/slides/sv/php-java/metered-licensing/).
{{% /alert %}} 

## **Köpt licens**

Efter köpet måste du tillämpa licensfilen eller -strömmen. 

{{% alert color="primary" %}}
Du måste ange licensen:
* endast en gång per applikationsdomän
* innan du använder någon annan Aspose.Slides‑klass
{{% /alert %}}

{{% alert color="primary" %}}
Du kan hitta prisinformation på sidan [“Prisinformation”](https://purchase.aspose.com/pricing/slides/sv/family).
{{% /alert %}}

### **Ange en licens i Aspose.Slides för PHP via Java**

Licenser kan tillämpas från följande platser:

* Explicit sökväg
* Ström
* Som en mätlicens – en ny licensmekanism

{{% alert color="primary" %}}
Använd **setLicense**‑metoden för att licensiera en komponent.

Även om flera anrop till **setLicense** inte är skadliga, är de ett slöseri med resurser (processor).
{{% /alert %}}

{{% alert color="warning" %}}
Nya licenser kan aktivera Aspose.Slides endast med version 21.4 eller senare. Tidigare versioner använder ett annat licenssystem och kommer inte att känna igen dessa licenser.
{{% /alert %}}

#### **Tillämpa en licens med en fil**

Det här kodavsnittet används för att ange en licensfil:

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense("Aspose.Slides.lic");
?>
```

När du anropar setLicense‑metoden ska licensnamnet vara samma som ditt licensfilnamn. Till exempel kan du ändra licensfilens namn till "Aspose.Slides.lic.xml". Därefter måste du i din kod skicka det nya licensnamnet (Aspose.Slides.lic.xml) till setLicense‑metoden.

#### **Tillämpa en licens från en ström**

Det här kodavsnittet används för att tillämpa en licens från en ström:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense($stream);
?>
```

## **FAQ**

**Kan jag tillämpa licensen i en helt offline‑miljö (ingen internetanslutning)?**

Ja. Licensvalidering utförs lokalt med licensfilen; ingen internetanslutning krävs.

**Vad händer när ettårs‑abonnemanget löper ut? Slutar biblioteket fungera?**

Nej. Licensen är evig: du kan fortsätta använda versioner som släppts före ditt abonnemangs slutdatum; du kommer bara inte att kunna använda nyare versioner utan att förnya.