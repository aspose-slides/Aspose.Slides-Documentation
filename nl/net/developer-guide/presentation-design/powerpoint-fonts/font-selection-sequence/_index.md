---
title: Lettertype-selectiesequentie in Aspose.Slides voor .NET
linktitle: Lettertype-selectie
type: docs
weight: 80
url: /nl/net/font-selection-sequence/
keywords:
- lettertype-selectie
- lettertype-substitutie
- lettertype-vervanging
- substitutieregel
- beschikbaar lettertype
- ontbrekend lettertype
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Ontdek hoe Aspose.Slides voor .NET lettertypen selecteert, waardoor PPT, PPTX en ODP-bestanden scherp en consistent worden gepresenteerd — verbeter nu uw dia's."
---
## **Overzicht**

Wanneer een presentatie wordt geladen, gerenderd of geconverteerd naar een ander formaat, houdt Aspose.Slides rekening met de ingebedde lettertypen en de lettertypen die beschikbaar zijn voor de applicatie. Als een vereist lettertype niet beschikbaar is, selecteert Aspose.Slides een vervangend lettertype dat zo dicht mogelijk bij het lettertype komt dat PowerPoint zou gebruiken.

Beschikbare lettertypen kunnen systeemlettertypen, door de applicatie geladen lettertypen en ingebedde lettertypen in de presentatie omvatten. Voor een overeenkomend ingebed en geregistreerd lettertype bepaalt de .NET 26.11‑voorkeur die hieronder wordt beschreven welke prioriteit heeft. Font‑substitutieregels gedefinieerd via [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) vormen een apart mechanisme.

U kunt ook lettertypen toevoegen tijdens de uitvoering van de applicatie, ingebedde lettertypen uit een presentatie gebruiken, of externe lettertypen laden voor outputdocumenten zoals PDF‑bestanden.

## **Lettertype‑selectie**

Tekst kan een themalettertype refereren, zoals `+mn-lt`, in plaats van een expliciete familienaam. Zie [Resolve Theme Font References](/slides/nl/net/presentation-theme/#resolve-theme-font-references) om de door het toepasselijke thema gespecificeerde familie op te halen. Het oplossen van die referentie is gescheiden van het controleren van de beschikbaarheid van het lettertype en het toepassen van substitutie tijdens het renderen of glyph‑fallback; het identificeert niet het lettertypebestand dat uiteindelijk wordt gebruikt om de tekst weer te geven.

Wanneer u dia's rendert of een presentatie converteert, controleer dan of de gevraagde lettertypen ingebed zijn of beschikbaar zijn vanuit geregistreerde bronnen. Ontbrekende lettertypen kunnen vervanging of substitutie vereisen; zie [**Lettertype‑vervanging**](/slides/nl/net/font-replacement/) en [**Lettertype‑substitutie**](/slides/nl/net/font-substitution/).

Bij het onderzoeken van lettertype‑selectie:

1. Los de gevraagde familie en stijl op, inclusief eventuele themareferentie.
2. Controleer ingebedde lettertypen en geregistreerde bronnen, inclusief systeemlettertypen en door de applicatie geladen lettertypen. Gebruik de onderstaande voorkeur wanneer overeenkomende ingebedde en geregistreerde versies met elkaar concurreren.
3. Bekijk [lettertype‑substitutieregels](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) en glyph‑fallback als het gevraagde lettertype of de tekens niet beschikbaar zijn.

Aspose.Slides stelt u in staat om lettertypen toe te voegen tijdens de uitvoering van de applicatie en die vervolgens te gebruiken. Zie [**Aangepaste lettertypen**](/slides/nl/net/custom-font/).

Wanneer extra lettertypen in een presentatie worden geplaatst, worden ze [**Ingebedde lettertypen**](/slides/nl/net/embedded-font/) genoemd.

Aspose.Slides stelt u in staat om lettertypen toe te voegen die alleen op outputdocumenten worden toegepast. Bijvoorbeeld, als een presentatie die u naar PDF wilt converteren lettertypen bevat die ontbreken op uw systeem en in de ingebedde lettertypen, kunt u de benodigde lettertypen toevoegen of laden als **externe lettertypen**.

{{% alert title="Note" color="info" %}} 
We distribueren geen lettertypen, noch betaald noch gratis. Onze API stelt u in staat om externe lettertypen te laden en in documenten in te sluiten, maar u doet dit met lettertypen naar eigen inzicht en verantwoordelijkheid.
{{% /alert %}}

## **Voorkeur geven aan geregistreerde lettertypen boven ingebedde lettertypen**

Vanaf .NET 26.11 laat [IFontsManager.PreferRegisteredFontsOverEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/preferregisteredfontsoverembedded/) een overeenkomend geregistreerd lettertype prioriteit krijgen boven een ingebed lettertype tijdens export. De standaardwaarde is `false`. Overeenstemming gebruikt de lettertype‑naam en stijl; een andere familienaam is geen vervangende overeenkomst. Geregistreerde lettertypen kunnen afkomstig zijn van het systeem of van [expliciet geladen lettertype‑bronnen](/slides/nl/net/custom-font/).

Het volgende voorbeeld gebruikt het **Aspose.Slides.NET6.CrossPlatform 26.11**‑pakket op .NET 8. Volg de [installatie‑handleiding](/slides/nl/net/installation/) voor uw omgeving. Lever `embedded-fonts.pptx` met een ingebed lettertype en `preferred.ttf` met dezelfde familienaam en stijl. De twee lettertype‑bestanden moeten duidelijk verschillen als u de output wilt vergelijken.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var fontBytes = File.ReadAllBytes("preferred.ttf");
FontsLoader.LoadExternalFont(fontBytes);
using var presentation = new Presentation("embedded-fonts.pptx");

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = false;
presentation.Save("embedded-preference.pdf", SaveFormat.Pdf);

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = true;
presentation.Save("registered-preference.pdf", SaveFormat.Pdf);

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = false;
presentation.Save("restored-preference.pdf", SaveFormat.Pdf);
```

Deze instelling wijzigt de prioriteit van lettertypen tijdens de export; het hernoemt het lettertype van de tekst niet, verwijdert geen ingebedde lettertype‑gegevens en embedt het geregistreerde bestand niet opnieuw. Het is een runtime‑instelling: stel het opnieuw in na het heropenen van een presentatie. Als er geen overeenkomend geregistreerd lettertype beschikbaar is, levert het inschakelen van de voorkeur er geen; controleer het resulterende lettertype en de lay-out in uw doelsysteem.

PNG‑ en PDF‑output met expliciet geladen reguliere lettertypen werd gecontroleerd voor de bovenstaande configuratie. Controleer uw eigen lettertype‑bestanden, stijlen, SDK‑build en output‑formaten voordat u op identieke resultaten rekent. Lettertype‑metingen kunnen regeleinden en positionering wijzigen. Gebruik [lettertype‑vervanging](/slides/nl/net/font-replacement/) of [substitutie](/slides/nl/net/font-substitution/) wanneer u een andere familie nodig hebt, en [operaties voor ingebedde lettertypen](/slides/nl/net/embedded-font/) wanneer u de in de presentatie opgeslagen lettertypen wilt wijzigen.

## **Veelgestelde vragen**

**Hoe kan ik bepalen welke lettertypen daadwerkelijk in een presentatie worden gebruikt vóór conversie?**

Aspose.Slides stelt u in staat de gebruikte lettertypen te inspecteren via de [lettertype‑beheerder](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/), zodat u kunt beslissen of u wilt [inbedden](/slides/nl/net/embedded-font/), [vervangen](/slides/nl/net/font-replacement/), of [externe bronnen](/slides/nl/net/custom-font/) toevoegen. Dit helpt u ongewenste substituties tijdens het renderen en exporteren te voorkomen.

**Kan ik extra lettertype‑mappen toevoegen zonder ze te installeren op het besturingssysteem?**

Ja. U kunt [externe lettertype‑bronnen](/slides/nl/net/custom-font/) zoals mappen of in‑memory‑streams registreren voor rendering en export. Dit verwijdert de afhankelijkheid van host‑systeemlettertypen en houdt de lay-out voorspelbaar.

**Hoe voorkom ik een stille fallback naar een ongeschikt lettertype wanneer een glyph ontbreekt?**

Definieer expliciete [lettertype‑vervanging](/slides/nl/net/font-replacement/) en font [fallback‑regels](/slides/nl/net/fallback-font/) vooraf. Door gebruikte lettertypen te analyseren en een gecontroleerde prioriteit voor substituten in te stellen, zorgt u voor consistente typografie en voorkomt u onverwachte resultaten.