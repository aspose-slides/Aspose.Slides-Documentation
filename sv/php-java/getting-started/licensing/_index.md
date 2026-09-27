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
description: "Tilldela, administrera och felsök licenser i Aspose.Slides för PHP via Java. Säkerställ oavbruten åtkomst till alla funktioner med vår steg-för-steg-guide för licensiering."
---
## **Introduktion**

Ibland kan en praktisk metod vara nödvändig för bästa utvärderingsresultat. Av den anledningen erbjuder Aspose.Slides olika inköpsplaner samt en Gratis provperiod och en 30-dagars tillfällig licens för utvärdering.

{{% alert color="info" title="Obs" %}}
Observera att det finns ett antal allmänna policyer och rutiner som vägleder dig i hur du utvärderar, licensierar korrekt och köper våra produkter. Du kan hitta dem i avsnittet ["Köppolicy och FAQ"](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Utvärdera Aspose.Slides**
Du kan enkelt ladda ner Aspose.Slides för utvärdering. Utvärderingspaketet är identiskt med det köpta paketet. Utvärderingsversionen blir helt enkelt licensierad när du lägger till några rader kod för att tillämpa licensen. 

## **Begränsningar för utvärderingsversionen**
Utvärderingsversionen av Aspose.Slides (utan en specificerad licens) erbjuder hela produktens funktionalitet, med två begränsningar:

* Den lägger till en utvärderingsvattenstämpeltextlåda i mitten av varje bild i varje presentation som sparas.
* Text som din kod läser från en presentation trunkeras till de första tecknen, följt av ett meddelande om utvärderingsbegränsningen. Text som din kod skriver sparas i sin helhet.

{{% alert color="info" title="Obs" %}}
Om du vill testa Aspose.Slides utan begränsningarna i utvärderingsversionen kan du begära en **30-dagars tillfällig licens**. Se [Hur får jag en tillfällig licens?](https://purchase.aspose.com/temporary-license) för mer information.
{{% /alert %}} 

## **Om licensen**
Du kan enkelt ladda ner en utvärderingsversion av Aspose.Slides för PHP via Java från dess [nedladdningssida](https://packagist.org/packages/aspose/slides). Utvärderingsversionen erbjuder absolut **samma funktioner** som den licensierade versionen av Aspose.Slides. Dessutom blir utvärderingsversionen licensierad när du köper en licens och lägger till ett par kodrader för att tillämpa licensen.

Licensen är en vanlig text‑XML‑fil som innehåller detaljer såsom produktnamn, antal utvecklare den är licensierad för, prenumerationsutgångsdatum med mera. Filen är digitalt signerad, så ändra inte filen. Även ett oavsiktligt extra radbryt i filens innehåll ogiltigförklarar den.

För att undvika begränsningarna som är förknippade med utvärderingsversionen måste du ange en licens innan du använder **Aspose.Slides**. Du behöver bara ange en licens en gång per applikation eller process.

{{% alert color="info" title="Obs" %}}
Du kan vilja se [Måttbaserad licensiering](/slides/sv/php-java/metered-licensing/).
{{% /alert %}} 

## **Köpt licens**

Efter köpet måste du tillämpa licensfilen eller strömmen. 

{{% alert color="info" title="Obs" %}}
Du måste ange licensen:
* endast en gång per applikationsdomän
* innan du använder några andra Aspose.Slides‑klasser
{{% /alert %}}

{{% alert color="info" title="Obs" %}}
Du kan hitta prisinformation på sidan [Prisinformation](https://purchase.aspose.com/pricing/slides/sv/family).
{{% /alert %}}

### **Ange en licens i Aspose.Slides för PHP via Java**

Licenser kan tillämpas från följande platser:

* Explicit sökväg
* Ström
* Som en måttbaserad licens – en ny licensieringsmekanism

{{% alert color="info" title="Obs" %}}
Använd metoden **setLicense** för att licensiera en komponent.

Även om flera anrop av **setLicense** inte är skadliga, är de en slöseri med resurser (processor).
{{% /alert %}}

{{% alert color="warning" title="Varning" %}}
Nya licenser kan aktivera Aspose.Slides endast med version 21.4 eller senare. Tidigare versioner använder ett annat licenssystem och kommer inte att känna igen dessa licenser.
{{% /alert %}}

#### **Tillämpa en licens med en fil**

Det här kodsnutten används för att ange en licensfil:

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/sv/lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense(__DIR__ . "/Aspose.Slides.lic");
```

Exemplet förväntar sig licensfilen bredvid skriptet och skickar dess absoluta sökväg: Aspose.Slides körs inuti Tomcat, så den löser inte en relativ sökväg mot ditt skriptmapp. När du anropar metoden setLicense bör licensnamnet vara samma som ditt licensfilnamn. Till exempel kan du ändra licensfilens namn till "Aspose.Slides.lic.xml". Då måste du i koden skicka det nya licensnamnet (Aspose.Slides.lic.xml) till setLicense‑metoden.

#### **Tillämpa en licens från en ström**

Det här kodsnutten används för att tillämpa en licens från en ström:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/sv/lib/aspose.slides.php");

use aspose\slides\License;

$stream = new Java("java.io.FileInputStream", __DIR__ . "/Aspose.Slides.lic");

$license = new License();
$license->setLicense($stream);

$stream->close();
```

## **Vanliga frågor**

### Kan jag tillämpa licensen i en helt offline-miljö (ingen internetåtkomst)?

Ja. Licensvalidering utförs lokalt med licensfilen; ingen internetanslutning krävs.

### Vad händer när ettårig prenumeration löper ut? Kommer biblioteket att sluta fungera?

Nej. Licensen är evig: du kan fortsätta använda versioner som släppts före ditt prenumerationsslutdatum; du kommer bara att vara behörig att använda nyare versioner utan förnyelse.