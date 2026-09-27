---
title: Licensiering
type: docs
weight: 120
url: /sv/cpp/licensing/
keywords:
- licens
- temporär licens
- ange licens
- använda licens
- validera licens
- licensfil
- utvärderingsversion
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Applicera, hantera och felsöka licenser i Aspose.Slides för C++. Säkerställ oavbruten åtkomst till alla funktioner med vår steg-för-steg-guide för licensiering."
---
## **Översikt**

Aspose.Slides kan användas i utvärderingsläge eller med en giltig licens. Utvärderingsversionen erbjuder samma funktionalitet som den licensierade versionen, men den lägger till ett utvärderingsvattenmärke på varje bild i varje presentation den sparar och trunkerar text som din kod läser från presentationer.

Den här artikeln förklarar hur licensiering fungerar i Aspose.Slides och hur du applicerar en licens innan du använder biblioteket. En licens kan läsas in från en fil eller en ström med hjälp av `License`‑klassen. Artikeln visar också hur du validerar om en licens har tillämpats korrekt.

## **Utvärdera Aspose.Slides**

{{% alert color="info" title="Note" %}}
Du kan ladda ner en utvärderingsversion av **Aspose.Slides for C++** från [dess NuGet-nedladdningssida](https://www.nuget.org/packages/Aspose.Slides.Cpp/) eller, som ett ZIP‑paket, från [nedladdningssidan](https://releases.aspose.com/slides/cpp/). Utvärderingsversionen erbjuder samma funktionalitet som den licensierade produkten. Faktum är att utvärderingspaketet är identiskt med det köpta – det blir helt enkelt licensierat när du lägger till några kodrader för att tillämpa licensen.

När du är nöjd med din utvärdering av **Aspose.Slides** kan du [köpa en licens](https://purchase.aspose.com/pricing/slides/cpp/). Vi rekommenderar att du granskar de tillgängliga prenumerationstyperna. Om du har några frågor, kontakta gärna Asposes försäljningsteam.

Varje Aspose-licens inkluderar ett ettårigt abonnemang för gratis uppgraderingar, inklusive nya versioner och felrättningar som släpps under perioden. Oavsett om du använder en licensierad eller utvärderingsversion får du gratis och obegränsad teknisk support.
{{% /alert %}} 

**Begränsningar i utvärderingsversionen**

* Utvärderingsversionen (utan angiven licens) ger full produktfunktionalitet, men den lägger till en utvärderingsvattenmärkes‑textlåda på varje bild i varje presentation den sparar.
* Text som din kod läser från en presentation trunkeras till de första tecknen, följt av en notering om utvärderingsbegränsningen. Text som din kod skriver sparas i sin helhet.

{{% alert color="info" title="Note" %}}
För att testa Aspose.Slides utan begränsningar kan du begära en **30‑dagars temporär licens**. För mer information, se sidan [How to Get a Temporary License](https://purchase.aspose.com/temporary-license).
{{% /alert %}}

## **Licensiering i Aspose.Slides**

* En utvärderingsversion blir licensierad efter att du köpt en licens och tillämpat den genom att lägga till ett par kodrader.
* Licensen är en ren text‑XML‑fil som innehåller detaljer som produktnamn, antal utvecklare den är licensierad för, abonnemangets utgångsdatum med mera.
* Licensfilen är digitalt signerad, så den får inte ändras. Även en oavsiktlig förändring – till exempel att lägga till en radbrytning – gör filen ogiltig.
* När du anger ett filnamn utan sökväg letar Aspose.Slides for C++ bara i den aktuella arbetskatalogen efter licensfilen. Den söker inte i mappen för ditt körbara program eller i Aspose.Slides‑biblioteket, så ange hela sökvägen när licensfilen lagras någon annanstans.
* För att undvika begränsningarna i utvärderingsversionen måste du sätta licensen innan du använder Aspose.Slides. En licens behöver bara sättas en gång per applikation eller process.

## **Tillämpa en licens**

En licens kan läsas in från en **fil** eller en **ström**.

{{% alert color="info" title="Note" %}}
Aspose.Slides tillhandahåller klassen [License](https://reference.aspose.com/slides/cpp/aspose.slides/license/) för licenshanteringsoperationer.
{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}
Nya licenser kan aktivera Aspose.Slides endast med version 21.4 eller senare. Tidigare versioner använder ett annat licenssystem och kommer inte att känna igen dessa licenser.
{{% /alert %}}

### **Fil**

Det enklaste sättet att ange en licens är att placera licensfilen i programmets arbetskatalog och ange endast filnamnet, utan sökväg. Annars anger du den fullständiga sökvägen till filen.

Följande C++-kod tillämpar licensfilen *Aspose.Slides.lic* från programmets arbetskatalog:

```c++
#include <Util/License.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    return 0;
}
```

Om licensen är giltig returnerar [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) och programmet avslutas utan utskrift; därefter fungerar Aspose.Slides utan utvärderingsbegränsningarna. Om filen inte finns i arbetskatalogen kastar metoden ett [FileNotFoundException](https://reference.aspose.com/slides/cpp/system.io/filenotfoundexception/) med meddelandet *License "Aspose.Slides.lic" doesn't exist or access is restricted*. Exemplet hanterar inte undantaget, så programmet stoppas.

{{% alert color="warning" title="Warning" %}}
Om du placerar licensfilen i en annan katalog, måste filnamnet i slutet av den angivna explicita sökvägen exakt matcha namnet på din licensfil när du anropar metoden [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/).

Till exempel, om du byter namn på licensfilen till *Aspose.Slides.lic.xml*, måste du skicka den fullständiga sökvägen som slutar med *Aspose.Slides.lic.xml* till metoden [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) i din kod.
{{% /alert %}}

### **Ström**

Läs in en licens från en ström när ditt program inte behåller licensen som en fil som det kan namnge, till exempel när den läser licensen från en databas. [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) accepterar vilken [Stream](https://reference.aspose.com/slides/cpp/system.io/stream/) som helst som innehåller licensen. För att hålla exemplet kort öppnar följande C++-kod *Aspose.Slides.lic* i arbetskatalogen med [File::OpenRead](https://reference.aspose.com/slides/cpp/system.io/file/openread/) och tillämpar licensen från den strömmen:

```c++
#include <Util/License.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

int main()
{
    auto license = MakeObject<License>();
    auto stream = File::OpenRead(u"Aspose.Slides.lic");
    license->SetLicense(stream);

    return 0;
}
```

En giltig licens ger samma resultat som i fil‑exemplet. Om filen inte finns kastar [File::OpenRead](https://reference.aspose.com/slides/cpp/system.io/file/openread/) ett [FileNotFoundException](https://reference.aspose.com/slides/cpp/system.io/filenotfoundexception/) innan licensen tillämpas, och programmet stoppas.

## **Validera en licens**

För att kontrollera om en licens har satts korrekt, anropa [License::IsLicensed](https://reference.aspose.com/slides/cpp/aspose.slides/license/islicensed/). Den returnerar `true` först efter att en giltig licens har tillämpats, och `false` innan dess. Följande C++-kod tillämpar licensfilen från arbetskatalogen och kontrollerar sedan den:

```c++
#include <Util/License.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    if (license->IsLicensed())
    {
        Console::WriteLine(u"License is good!");
    }

    return 0;
}
```

Med en giltig licens skriver programmet ut *License is good!*. Om filen saknas eller inte är en licensfil kastar [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) ett undantag innan kontrollen, och programmet stoppas utan att skriva ut något. Om filen är en licens vars signatur inte matchar, till exempel för att den redigerats, returnerar SetLicense utan fel men `IsLicensed` returnerar `false`, så inget skrivs ut och Aspose.Slides förblir i utvärderingsläge.

## **Trådsäkerhet**

{{% alert color="warning" title="Warning" %}}
[License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/)‑metoden är **inte trådsäker**. Om du måste anropa denna metod från flera trådar samtidigt rekommenderas att du använder synkroniseringsprimitiver (såsom en lås) för att förhindra potentiella problem.
{{% /alert %}}

## **FAQ**

### Kan jag tillämpa licensen i en helt offline‑miljö (ingen internetåtkomst)?

Ja. Licensvalidering utförs lokalt med licensfilen; ingen internetanslutning krävs.

### Vad händer när ettårsabonnemanget löper ut? Slutar biblioteket att fungera?

Nej. Licensen är evig: du kan fortsätta använda versioner som släppts innan ditt abonnemangs slutdatum; du kommer bara inte att vara berättigad att använda nyare versioner utan förnyelse.