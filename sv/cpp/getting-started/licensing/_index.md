---
title: Licensiering
type: docs
weight: 120
url: /sv/cpp/licensing/
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
- C++
- Aspose.Slides
description: "Tillämpar, hanterar och felsöker licenser i Aspose.Slides för C++. Säkerställ oavbruten åtkomst till alla funktioner med vår steg-för-steg-guide för licensiering."
---
## **Översikt**

Aspose.Slides kan användas i evalueringsläge eller med en giltig licens. Utvärderingsversionen erbjuder samma funktionalitet som den licensierade versionen, men den lägger till ett utvärderingsvattenmärke när presentationer öppnas eller sparas och begränsar textutdragning till en enda bild.

Denna artikel förklarar hur licensiering fungerar i Aspose.Slides och hur du tillämpar en licens innan du använder biblioteket. En licens kan laddas från en fil, en ström eller en inbäddad resurs genom att använda `License`-klassen. Artikeln visar också hur du validerar om en licens har tillämpats korrekt.

## **Utvärdera Aspose.Slides**

{{% alert color="primary" %}} 

Du kan ladda ner en utvärderingsversion av **Aspose.Slides for C++** från [dess NuGet‑nedladdningssida](https://www.nuget.org/packages/Aspose.Slides.CPP/). Utvärderingsversionen erbjuder samma funktionalitet som den licensierade produkten. Faktum är att utvärderingspaketet är identiskt med det köpta – det blir helt enkelt licensierat när du lägger till några rader kod för att tillämpa licensen.

När du är nöjd med din utvärdering av **Aspose.Slides** kan du [köpa en licens](https://purchase.aspose.com/buy). Vi rekommenderar att du granskar de tillgängliga prenumerationstyperna. Om du har några frågor, tveka inte att kontakta Aspose‑försäljningsteamet.

Varje Aspose‑licens inkluderar ett ettårsabonnemang för gratis uppgraderingar, inklusive nya versioner och felrättningar som släpps under den perioden. Oavsett om du använder en licensierad eller utvärderingsversion får du gratis och obegränsad teknisk support.

{{% /alert %}} 

**Begränsningar för utvärderingsversionen**

* Även om Aspose.Slides utvärderingsversion (när ingen licens har tillämpats) ger full produktfunktionalitet, infogar den ett utvärderingsvattenmärke högst upp i dokumentet under öppnings‑ och sparningsoperationer.
* Textutdragning är begränsad till en bild när du använder utvärderingsversionen.

{{% alert color="primary" %}} 

För att testa Aspose.Slides utan begränsningar kan du begära en **30‑dagars tillfällig licens**. För mer information, se sidan [Hur du får en tillfällig licens](https://purchase.aspose.com/temporary-license).

{{% /alert %}}

## **Licensiering i Aspose.Slides**

* En utvärderingsversion blir licensierad efter att du köpt en licens och tillämpat den genom att lägga till ett par rader kod.
* Licensen är en ren text‑XML‑fil som innehåller detaljer såsom produktnamn, antalet utvecklare den är licensierad för, prenumerationens utgångsdatum och mer.
* Licensfilen är digitalt signerad, så den får inte ändras. Även en oavsiktlig ändring – som att lägga till en radbrytning – gör filen ogiltig.
* Aspose.Slides for C++ söker vanligtvis efter licensfilen på följande platser:
  * En sökväg som explicit anges i din kod
  * Mappen som innehåller komponentens DLL (inkluderad i Aspose.Slides)
  * Mappen som innehåller den assembly som anropar komponentens DLL
* För att undvika begränsningarna i utvärderingsversionen måste du ange licensen innan du använder Aspose.Slides. En licens behöver endast anges en gång per applikation eller process.

## **Tillämpa en licens**

En licens kan laddas från en **fil**, en **ström** eller en **inbäddad resurs**.

{{% alert color="primary" %}}

Aspose.Slides tillhandahåller klassen [License](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.license/) för licenshantering.

{{% /alert %}} 

{{% alert color="warning" %}}

Nya licenser kan aktivera Aspose.Slides endast med version 21.4 eller senare. Äldre versioner använder ett annat licenssystem och kommer inte att känna igen dessa licenser.

{{% /alert %}}

### **Fil**

Det enklaste sättet att ange en licens är att placera licensfilen i samma mapp som komponentens DLL (inkluderad i Aspose.Slides) och ange endast filnamnet, utan sökväg.

Följande C++‑kod visar hur man anger en licensfil:

```c++
#include <Util/License.h>

using namespace Aspose::Slides;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    return 0;
}
```

{{% alert color="warning" %}} 

Om du placerar licensfilen i en annan katalog, måste filnamnet i slutet av den specificerade explicita sökvägen exakt matcha namnet på din licensfil när du anropar metoden [License::SetLicense](https://reference.aspose.com/slides/sv/cpp/aspose.slides/license/setlicense/).

Till exempel, om du byter namn på licensfilen till *Aspose.Slides.lic.xml*, måste du skicka hela sökvägen som slutar med *Aspose.Slides.lic.xml* till metoden [License::SetLicense](https://reference.aspose.com/slides/sv/cpp/aspose.slides/license/setlicense/) i din kod.

{{% /alert %}}

### **Ström**

Du kan ladda en licens från en ström. Följande C++‑kod visar hur man tillämpar en licens från en ström:

```c++
auto license = MakeObject<License>();

auto stream = File::OpenRead(u"Aspose.Slides.lic");

license->SetLicense(stream);
```

## **Validera en licens**

För att kontrollera om en licens har ställts in korrekt kan du validera den. Följande C++‑kod visar hur man validerar en licens:

```c++
auto license = MakeObject<License>();

license->SetLicense(u"Aspose.Slides.lic");

if (license->IsLicensed())
{
    Console::WriteLine(u"License is good!");
    Console::ReadKey();
}
```

## **Tråd‑säkerhet**

{{% alert title="Note" color="warning" %}} 

Metoden [License::SetLicense](https://reference.aspose.com/slides/sv/cpp/aspose.slides/license/setlicense/) är **inte trådsäker**. Om du behöver anropa denna metod från flera trådar samtidigt rekommenderas det att använda synkroniseringsprimitiver (t.ex. ett lås) för att förhindra potentiella problem.

{{% /alert %}}

## **FAQ**

**Kan jag tillämpa licensen i en helt offline-miljö (ingen internetåtkomst)?**

Ja. Licensvalideringen utförs lokalt med licensfilen; ingen internetanslutning krävs.

**Vad händer när det ettårsabonnemanget löper ut? Slutar biblioteket fungera?**

Nej. Licensen är evig: du kan fortsätta använda versioner som släppts innan ditt abonnemangs slutdatum; du kommer bara inte kunna använda nyare releaser utan att förnya.