---
title: Licensiering
type: docs
weight: 120
url: /sv/cpp/licensing/
keywords:
- licens
- temporär licens
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
description: "Applicera, hantera och felsök licenser i Aspose.Slides för C++. Säkerställ oavbruten åtkomst till alla funktioner med vår steg-för-steg-guide för licensiering."
---
## **Översikt**

Aspose.Slides kan användas i evalueringsläge eller med en giltig licens. Evalueringsversionen erbjuder samma funktionalitet som den licensierade versionen, men den lägger till ett evalueringsvattenstämpel när presentationer öppnas eller sparas och begränsar textutdragning till en bild.

Denna artikel förklarar hur licensiering fungerar i Aspose.Slides och hur du tillämpar en licens innan du använder biblioteket. En licens kan laddas från en fil, en ström eller en inbäddad resurs med hjälp av `License`-klassen. Artikeln visar också hur du validerar om en licens har tillämpats korrekt.

## **Utvärdera Aspose.Slides**

{{% alert color="info" %}} 
Du kan ladda ner en evalueringsversion av **Aspose.Slides för C++** från [dess NuGet-nedladdningssida](https://www.nuget.org/packages/Aspose.Slides.CPP/). Evalueringsversionen erbjuder samma funktionalitet som den licensierade produkten. Faktum är att evalueringspaketet är identiskt med det köpta – det blir helt enkelt licensierat när du lägger till några rader kod för att tillämpa licensen.

När du är nöjd med din utvärdering av **Aspose.Slides** kan du [köpa en licens](https://purchase.aspose.com/buy). Vi rekommenderar att du går igenom de tillgängliga prenumerationstyperna. Om du har några frågor, tveka inte att kontakta Aspose säljteam.

Varje Aspose-licens inkluderar ett ettårigt abonnemang för gratis uppgraderingar, inklusive nya versioner och buggfixar som släpps under den perioden. Oavsett om du använder en licensierad eller en evalueringsversion får du gratis och obegränsad teknisk support.
{{% /alert %}} 

**Begränsningar i evalueringsversionen**

* Medan Aspose.Slides evalueringsversion (när ingen licens har tillämpats) ger full produktfunktionalitet, infogar den ett evalueringsvattenstämpel högst upp i dokumentet under öppnings- och spara‑operationer.
* Textutdragning är begränsad till en bild när du använder evalueringsversionen.

{{% alert color="info" %}} 
För att testa Aspose.Slides utan begränsningar kan du begära en **30-dagars temporär licens**. För mer information, se sidan [How to Get a Temporary License](https://purchase.aspose.com/temporary-license).
{{% /alert %}}

## **Licensiering i Aspose.Slides**

* En evalueringsversion blir licensierad efter att du har köpt en licens och tillämpat den genom att lägga till ett par kodrader.
* Licensen är en rentext-XML-fil som innehåller detaljer såsom produktnamn, antalet utvecklare den är licensierad till, prenumerationens utgångsdatum och mer.
* Licensfilen är digitalt signerad, så den får inte ändras. Även en oavsiktlig ändring—såsom att lägga till ett radbrytning—gör filen ogiltig.
* Aspose.Slides för C++ söker vanligtvis efter licensfilen på följande platser:
  * En sökväg som uttryckligen anges i din kod
  * Mappen som innehåller komponentens DLL (inkluderad i Aspose.Slides)
  * Mappen som innehåller den assembly som anropar komponentens DLL
* För att undvika begränsningarna i evalueringsversionen måste du ange licensen innan du använder Aspose.Slides. En licens behöver endast anges en gång per applikation eller process.

## **Applicera en licens**

En licens kan laddas från en **fil**, en **ström** eller en **inbäddad resurs**.

{{% alert color="info" %}}
Aspose.Slides tillhandahåller klassen [Licens](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.license/) för licenshantering.
{{% /alert %}} 

{{% alert color="warning" %}}
Nya licenser kan aktivera Aspose.Slides endast med version 21.4 eller senare. Tidigare versioner använder ett annat licenssystem och kommer inte att känna igen dessa licenser.
{{% /alert %}}

### **Fil**

Det enklaste sättet att ange en licens är att placera licensfilen i samma mapp som komponentens DLL (inkluderad i Aspose.Slides) och ange endast filnamnet, utan någon sökväg.

Följande C++-kod visar hur du anger en licensfil:

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

{{% alert color="warning" %}} 
Om du placerar licensfilen i en annan katalog, måste filnamnet i slutet av den angivna explicita sökvägen exakt matcha namnet på din licensfil när du anropar metoden [License::SetLicense](https://reference.aspose.com/slides/sv/cpp/aspose.slides/license/setlicense/).

Till exempel, om du byter namn på din licensfil till *Aspose.Slides.lic.xml*, måste du skicka den fullständiga sökvägen som slutar med *Aspose.Slides.lic.xml* till metoden [License::SetLicense](https://reference.aspose.com/slides/sv/cpp/aspose.slides/license/setlicense/) i din kod.
{{% /alert %}}

### **Ström**

Du kan ladda en licens från en ström. Följande C++-kod visar hur du tillämpar en licens från en ström:

```c++
#include <Util/License.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto license = MakeObject<License>();

auto stream = File::OpenRead(u"Aspose.Slides.lic");

license->SetLicense(stream);
```

## **Validera en licens**

För att kontrollera om en licens har ställts in korrekt kan du validera den. Följande C++-kod visar hur du validerar en licens:

```c++
#include <Util/License.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto license = MakeObject<License>();

license->SetLicense(u"Aspose.Slides.lic");

if (license->IsLicensed())
{
    Console::WriteLine(u"License is good!");
    Console::ReadKey();
}
```

## **Trådsäkerhet**

{{% alert title="Obs" color="warning" %}} 
Metoden [License::SetLicense](https://reference.aspose.com/slides/sv/cpp/aspose.slides/license/setlicense/) är **inte trådsäker**. Om du behöver anropa denna metod från flera trådar samtidigt rekommenderas det att använda synkroniseringsprimitiver (t.ex. ett lås) för att förhindra potentiella problem.
{{% /alert %}}

## **FAQ**

### Kan jag tillämpa licensen i en helt offline-miljö (utan internetuppkoppling)?

Ja. Licensvalidering utförs lokalt med licensfilen; ingen internetanslutning krävs.

### Vad händer när det ettåriga abonnemanget löper ut? Slutar biblioteket att fungera?

Nej. Licensen är evig: du kan fortsätta använda versioner som släppts före ditt abonnemangs slutdatum; du kommer bara inte att vara berättigad att använda nyare versioner utan att förnya.