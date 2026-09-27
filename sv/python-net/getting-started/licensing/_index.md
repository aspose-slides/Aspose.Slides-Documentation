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
description: "Lär dig hur du applicerar, hanterar och felsöker licenser i Aspose.Slides för Python via .NET. Säkerställ oavbruten åtkomst till alla funktioner med vår steg-för-steg-guide för licensiering."
---
## **Översikt**

Aspose.Slides kan användas i evalueringsläge eller med en giltig licens. Evalueringsversionen ger samma funktionalitet som den licensierade versionen, men den lägger till ett utvärderingsvattenstämpel på varje bild i varje presentation som den sparar och trunkerar text som din kod läser från presentationer.

## **Utvärdera Aspose.Slides**

Du kan ladda ner en evalueringsversion av **Aspose.Slides for Python via .NET** från dess [nedladdningssida](https://pypi.org/project/Aspose.Slides/). Evalueringsversionen ger samma funktioner som den licensierade produkten. Evalueringspaketet är identiskt med det köpta paketet och blir licensierat efter att du har lagt till några kodrader för att applicera licensen.

När du är nöjd med din utvärdering av **Aspose.Slides**, kan du [köpa en licens](https://purchase.aspose.com/pricing/slides/python-net/). Vi rekommenderar att du går igenom de tillgängliga prenumerationsalternativen. Om du har frågor, kontakta Asposes försäljningsteam.

Varje Aspose-licens inkluderar ett ettårigt abonnemang med gratis uppgraderingar till nya versioner och korrigeringar som släpps under den perioden. Både licensierade och evalueringsanvändare får gratis, obegränsad teknisk support.

**Begränsningar i evalueringsversionen**

* Evalueringsversionen (när ingen licens har tillämpats) erbjuder full funktionalitet, men den lägger till en evalueringsvattenstämpel i en textruta på varje bild i varje presentation som den sparar.
* Text som din kod läser från en presentation trunkeras till de första några tecknen, följt av ett meddelande om evalueringsbegränsningen. Text som din kod skriver sparas i sin helhet.

{{% alert color="info" title="Obs" %}}
För att testa Aspose.Slides utan begränsningar kan du begära en **30‑dagars tillfällig licens**. Se sidan [Hur man får en tillfällig licens](https://purchase.aspose.com/temporary-license) för detaljer.
{{% /alert %}}

## **Licensiering i Aspose.Slides**

* En evalueringsversion blir licensierad efter att du köpt en licens och lagt till ett par kodrader för att applicera den.
* Licensen är en ren text‑XML‑fil som innehåller detaljer såsom produktnamn, antalet utvecklare den täcker, abonnemangets utgångsdatum osv.
* Licensfilen är digitalt signerad, så du får inte ändra den. Även ett enda radbrytning gör den ogiltig.
* Aspose.Slides for Python via .NET söker efter licensen på den sökväg du anger. En relativ sökväg eller ett filnamn utan sökväg löses mot den aktuella arbetskatalogen, som inte nödvändigtvis är mappen som innehåller ditt Python‑skript.
* För att undvika evalueringsbegränsningarna, sätt licensen innan du använder Aspose.Slides. Du behöver bara sätta den en gång per applikation eller process.

{{% alert color="info" title="Obs" %}}
Du kan också vilja granska [Metered Licensing](/slides/sv/python-net/metered-licensing/).
{{% /alert %}}

## **Applicera en licens**

En licens kan läsas in från en **fil** eller en **ström**.

{{% alert color="info" title="Obs" %}}
Aspose.Slides tillhandahåller klassen [License](https://reference.aspose.com/slides/python-net/aspose.slides/license/) för att hantera licensiering.
{{% /alert %}}

{{% alert color="warning" title="Varning" %}}
Nya licenser kan aktivera Aspose.Slides endast med version 21.4 eller senare. Tidigare versioner använder ett annat licenssystem och kommer inte att känna igen dessa licenser.
{{% /alert %}}

### **Fil**

Det enklaste sättet att ange en licens är att skicka sökvägen till licensfilen till metoden [set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/). Om du bara anger filnamnet, som i exemplet nedan, söker Aspose.Slides efter filen i den aktuella arbetskatalogen.

Följande Python‑kod visar hur du anger licensfilen:

```py
import aspose.slides as slides

# Instansierar License-klassen. 
license = slides.License()

# Anger sökvägen till licensfilen.
license.set_license("Aspose.Slides.lic")
```

{{% alert color="warning" title="Varning" %}}
Om du placerar licensfilen i en annan katalog, måste filnamnet i slutet av den explicita sökvägen matcha licensfilens namn när du anropar [License.set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/#str).

Till exempel kan du döpa om licensfilen till *Aspose.Slides.lic.xml*. Sedan, i din kod, ange den fullständiga sökvägen till den filen (slutande med Aspose.Slides.lic.xml) till metoden [License.set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/#str).
{{% /alert %}}

### **Ström**

Du kan läsa in en licens från en ström. Följande Python‑exempel visar hur du applicerar en licens från en ström:

```py
import aspose.slides as slides

# Instansierar License-klassen.
license = slides.License()

# Sätter licensen från en ström.
with open("Aspose.Slides.lic", "rb") as stream:
    license.set_license(stream)
```

## **Validera en licens**

För att verifiera att licensen har applicerats korrekt kan du validera den. Följande Python‑kod demonstrerar hur du validerar en licens:

```py
import aspose.slides as slides

license = slides.License()

license.set_license("Aspose.Slides.lic")

if license.is_licensed():
    print("License is good!")
```

## **Trådsäkerhet**

{{% alert color="warning" title="Varning" %}}
Metoden [License.set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/) är inte trådsäker. Om du behöver anropa den parallellt från flera trådar, använd en synkroniseringsprimitive, såsom `threading.Lock`, för att undvika problem.
{{% /alert %}}

## **FAQ**

### Kan jag applicera licensen i en helt offline‑miljö (ingen internetåtkomst)?

Ja. Licensvalidering sker lokalt med licensfilen; ingen internetanslutning krävs.

### Vad händer när det ettåriga abonnemanget löper ut? Slutar biblioteket fungera?

Nej. Licensen är evig: du kan fortsätta använda versioner som släppts före ditt abonnemangs slutdatum; du kommer bara inte att kunna använda nyare releaser utan att förnya.