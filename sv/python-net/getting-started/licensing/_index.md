---
title: Licensiering
type: docs
weight: 80
url: /sv/python-net/licensing/
keywords:
- licens
- tillfällig licens
- ange licens
- använd licens
- validera licens
- licensfil
- utvärderingsversion
- Python
- Aspose.Slides
description: "Lär dig hur du tillämpar, hanterar och felsöker licenser i Aspose.Slides för Python via .NET. Säkerställ oavbruten åtkomst till alla funktioner med vår steg-för-steg-guide för licensiering."
---
## **Översikt**

Aspose.Slides kan användas i utvärderingsläge eller med en giltig licens. Utvärderingsversionen ger samma funktionalitet som den licensierade versionen, men den lägger till ett vattenstämpel för utvärdering när presentationer öppnas eller sparas och begränsar textutdragning till en bild.

## **Utvärdera Aspose.Slides**

Du kan ladda ner en utvärderingsversion av **Aspose.Slides for Python via .NET** från dess [nedladdningssida](https://pypi.org/project/Aspose.Slides/). Utvärderingsversionen ger samma funktioner som den licensierade produkten. Utvärderingspaketet är identiskt med det köpta paketet och blir licensierat efter att du lagt till några kodrader för att applicera licensen.

När du är nöjd med din utvärdering av **Aspose.Slides**, kan du [köpa en licens](https://purchase.aspose.com/buy). Vi rekommenderar att du granskar de tillgängliga prenumerationsalternativen. Om du har frågor, kontakta Aspose försäljningsteam.

Varje Aspose-licens inkluderar ett ettårigt abonnemang med gratis uppgraderingar till nya versioner och korrigeringar som släpps under den perioden. Både licensierade och utvärderande användare får gratis, obegränsad teknisk support.

**Begränsningar i utvärderingsversionen**

* Medan Aspose.Slides utvärderingsversion (när ingen licens har tillämpats) ger full funktionalitet, lägger den till ett vattenstämpel för utvärdering högst upp i dokumentet varje gång du öppnar eller sparar det.
* Vid textutdragning från en presentation är du begränsad till en bild.

{{% alert color="primary" %}}

För att testa Aspose.Slides utan begränsningar kan du begära en **30‑dagars tillfällig licens**. Se sidan [Hur man får en temporär licens](https://purchase.aspose.com/temporary-license) för detaljer.

{{% /alert %}}

## **Licensiering i Aspose.Slides**

* En utvärderingsversion blir licensierad efter att du köpt en licens och lagt till ett par kodrader för att tillämpa den.
* Licensen är en rentext‑XML‑fil som innehåller detaljer såsom produktnamn, antal utvecklare den omfattar, prenumerationens utgångsdatum med mera.
* Licensfilen är digitalt signerad, så du får inte ändra den. Även ett enda radbrytning gör den ogiltig.
* Aspose.Slides for Python via .NET söker vanligtvis efter licensen på följande platser:
  * En explicit sökväg som du anger
  * Mappen som innehåller Python‑skriptet som anropar Aspose.Slides for Python via .NET
* För att undvika utvärderingsbegränsningarna, sätt licensen innan du använder Aspose.Slides. Du behöver bara göra det en gång per applikation eller process.

{{% alert color="primary" %}}

Du kanske också vill granska [Metered Licensing](/slides/sv/python-net/metered-licensing/).

{{% /alert %}}

## **Applicera en licens**

En licens kan läsas in från en **fil**, **ström** eller **inbäddad resurs**. 

{{% alert color="primary" %}}

Aspose.Slides tillhandahåller klassen [License](https://reference.aspose.com/slides/sv/python-net/aspose.slides/license/) för att hantera licensiering.

{{% /alert %}}

{{% alert color="warning" %}}

Nya licenser kan aktivera Aspose.Slides endast med version 21.4 eller senare. Tidigare versioner använder ett annat licenssystem och kommer inte att känna igen dessa licenser.

{{% /alert %}}

### **Fil**

Det enklaste sättet att sätta en licens är att placera licensfilen i samma mapp som komponentens DLL och ange endast filnamnet (utan någon sökväg).

Följande Python‑kod visar hur du ställer in licensfilen:

```py
import aspose.slides as slides

# Skapar en instans av License-klassen.
license = slides.License()

# Anger sökvägen till licensfilen.
license.set_license("Aspose.Slides.lic")
```

{{% alert color="warning" %}}

Om du placerar licensfilen i en annan katalog, när du anropar [License.set_license()](https://reference.aspose.com/slides/sv/python-net/aspose.slides/license/set_license/#str), måste filnamnet i slutet av den explicita sökvägen matcha licensfilens namn.

Till exempel kan du byta namn på licensfilen till *Aspose.Slides.lic.xml*. Då, i din kod, skicka hela sökvägen till den filen (som slutar med Aspose.Slides.lic.xml) till metoden [License.set_license()](https://reference.aspose.com/slides/sv/python-net/aspose.slides/license/set_license/#str).

{{% /alert %}}

### **Ström**

Du kan läsa in en licens från en ström. Följande Python‑exempel visar hur du tillämpar en licens från en ström:

```py
import aspose.slides as slides

# Skapar en instans av License-klassen.
license = slides.License()

# Anger licensen från en ström.
license.set_license(stream)
```

## **Validera en licens**

För att verifiera att licensen har tillämpats korrekt kan du validera den. Följande Python‑kod demonstrerar hur du validerar en licens:

```py
import aspose.slides as slides

license = slides.License()

license.set_license("Aspose.Slides.lic")

if license.is_licensed():
    print("License is good!")
```

## **Trådsäkerhet**

{{% alert title="Obs" color="warning" %}}

Metoderna [License.set_license](https://reference.aspose.com/slides/sv/python-net/aspose.slides/license/) är inte trådsäkra. Om de behöver anropas samtidigt från flera trådar, använd synkroniseringsprimitiver (t.ex. `threading.Lock`) för att undvika problem.

{{% /alert %}}

## **FAQ**

**Kan jag tillämpa licensen i en helt offline‑miljö (utan internetuppkoppling)?**

Ja. Licensvalidering utförs lokalt med licensfilen; ingen internetanslutning krävs.

**Vad händer när det ettåriga abonnemanget löper ut? Slutar biblioteket att fungera?**

Nej. Licensen är livslång: du kan fortsätta använda versioner som släppts innan ditt abonnemangs slutdatum; du kommer bara inte att kunna använda nyare utgåvor utan förnyelse.