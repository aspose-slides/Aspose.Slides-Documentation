---
title: Presentaties beveiligen met wachtwoorden in C++
linktitle: Wachtwoordbeveiliging
type: docs
weight: 20
url: /nl/cpp/password-protected-presentation/
keywords:
- PowerPoint vergrendelen
- presentatie vergrendelen
- PowerPoint ontgrendelen
- presentatie ontgrendelen
- PowerPoint beschermen
- presentatie beschermen
- wachtwoord instellen
- wachtwoord toevoegen
- PowerPoint versleutelen
- presentatie versleutelen
- PowerPoint ontsleutelen
- presentatie ontsleutelen
- schrijfbeveiliging
- PowerPoint-beveiliging
- presentatiebeveiliging
- wachtwoord verwijderen
- beveiliging verwijderen
- versleuteling verwijderen
- wachtwoord uitschakelen
- beveiliging uitschakelen
- schrijfbeveiliging verwijderen
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe je moeiteloos PowerPoint- en OpenDocument-presentaties met een wachtwoord kunt vergrendelen en ontgrendelen met Aspose.Slides voor C++. Bescherm je presentaties."
---
## **Inleiding**

Wanneer je een presentatie met een wachtwoord beschermt, stel je een wachtwoord in dat bepaalde beperkingen op de presentatie afdwingt. Om de beperkingen te verwijderen, moet het wachtwoord worden ingevoerd. Een met wachtwoord beschermde presentatie wordt beschouwd als een vergrendelde presentatie.

Doorgaans kun je een wachtwoord instellen om deze beperkingen op een presentatie af te dwingen:

- **Wijziging**

  Als je wilt dat alleen bepaalde gebruikers je presentatie mogen wijzigen, kun je een wijzigingsbeperking instellen. Deze beperking voorkomt dat mensen wijzigingen aanbrengen, zaken aanpassen of kopiëren in je presentatie (tenzij ze het wachtwoord invoeren). 

  Echter, in dit geval kan een gebruiker, zelfs zonder het wachtwoord, toegang krijgen tot je document en het openen. In deze alleen‑lezen modus kan de gebruiker de inhoud of elementen — hyperlinks, animaties, effecten en andere — binnen je presentatie bekijken, maar hij kan geen items kopiëren of de presentatie opslaan. 

- **Openen**

  Als je wilt dat alleen bepaalde gebruikers je presentatie mogen openen, kun je een openingsbeperking instellen. Deze beperking verhindert dat mensen zelfs de inhoud van je presentatie kunnen bekijken (tenzij ze het wachtwoord invoeren).

  Technisch gezien voorkomt de openingsbeperking ook dat gebruikers je presentaties wijzigen: wanneer mensen een presentatie niet kunnen openen, kunnen ze deze niet aanpassen of wijzigen. 
  
  **Opmerking** dat wanneer je een presentatie met een wachtwoord beschermt om openen te voorkomen, het presentatiedbestand versleuteld wordt.

## **Hoe een presentatie online met een wachtwoord beveiligen**

1. Ga naar onze [**Aspose.Slides Lock**](https://products.aspose.app/slides/nl/lock) pagina. 

   ![todo:image_alt_text](slides-lock.png)

2. Klik op **Sleep of upload je bestanden**.

3. Selecteer het bestand dat je wilt beveiligen met een wachtwoord op je computer. 

4. Voer je gewenste wachtwoord in voor bewerkingsbescherming; Voer je gewenste wachtwoord in voor weergavebescherming. 

5. Als je wilt dat gebruikers je presentatie zien als de definitieve kopie, zet dan een vinkje bij het **Mark as final** selectievak.

6. Klik op **PROTECT NOW.** 

7. Klik op **DOWNLOAD NOW.**

## **Wachtwoordbeveiliging voor presentaties in Aspose.Slides**
**Ondersteunde indelingen**

Aspose.Slides ondersteunt wachtwoordbeveiliging, versleuteling en vergelijkbare bewerkingen voor presentaties in deze indelingen: 

- PPTX en PPT - Microsoft PowerPoint‑presentatie 
- ODP - OpenDocument‑presentatie 
- OTP - OpenDocument‑presentatiesjabloon 

**Ondersteunde bewerkingen**

Aspose.Slides stelt je in staat om wachtwoordbeveiliging toe te passen op presentaties om wijzigingen te voorkomen op de volgende manieren:

- Een presentatie versleutelen
- Schrijfbeveiliging instellen voor een presentatie

**Andere bewerkingen**

Aspose.Slides stelt je in staat om andere taken met betrekking tot wachtwoordbeveiliging en versleuteling uit te voeren op de volgende manieren:

- Een presentatie ontsleutelen; een versleutelde presentatie openen
- Versleuteling verwijderen; wachtwoordbeveiliging uitschakelen
- Schrijfbeveiliging van een presentatie verwijderen
- De eigenschappen van een versleutelde presentatie ophalen
- Controleren of een presentatie versleuteld is
- Controleren of een presentatie met een wachtwoord is beveiligd.

## **Een presentatie versleutelen**

Je kunt een presentatie versleutelen door een wachtwoord in te stellen. Om vervolgens de vergrendelde presentatie te wijzigen, moet een gebruiker het wachtwoord opgeven. 

Om een presentatie te versleutelen of met een wachtwoord te beveiligen, moet je de encrypt‑methode (van [ProtectionManager](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.protection_manager)) gebruiken om een wachtwoord voor de presentatie in te stellen. Je geeft het wachtwoord door aan de encrypt‑methode en gebruikt de save‑methode om de nu versleutelde presentatie op te slaan. 

Deze voorbeeldcode toont hoe je een presentatie versleutelt:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Schrijfbeveiliging voor een presentatie instellen** 

Je kunt een markering toevoegen met de tekst “Do not modify” aan een presentatie. Op deze manier kun je gebruikers laten weten dat je niet wilt dat ze wijzigingen aanbrengen in de presentatie.  

**Opmerking** dat het proces van schrijfbeveiliging de presentatie niet versleutelt. Gebruikers—als ze dat willen—kunnen de presentatie wijzigen, maar om de wijzigingen op te slaan moeten ze een presentatie met een andere naam maken. 

Om een schrijfbeveiliging in te stellen, moet je de setWriteProtection‑methode gebruiken. Deze voorbeeldcode toont hoe je een schrijfbeveiliging aan een presentatie toevoegt:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Een versleutelde presentatie laden**

Aspose.Slides stelt je in staat een versleuteld bestand te laden door het wachtwoord door te geven. Om een presentatie te ontsleutelen, moet je de [RemoveEncryption](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d)‑methode zonder parameters aanroepen. Vervolgens moet je het correcte wachtwoord invoeren om de presentatie te laden. 

Deze voorbeeldcode toont hoe je een presentatie ontsleutelt: 

``` cpp
#include <DOM/LoadOptions.h>
using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// werk met ontsleutelde presentatie
```

## **Versleuteling van een presentatie verwijderen**

Je kunt de versleuteling of wachtwoordbeveiliging van een presentatie verwijderen. Zo kunnen gebruikers de presentatie zonder beperkingen openen of wijzigen. 

Om versleuteling of wachtwoordbeveiliging te verwijderen, moet je de [RemoveEncryption](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d)‑methode aanroepen. Deze voorbeeldcode toont hoe je de versleuteling van een presentatie verwijdert:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Schrijfbeveiliging van een presentatie verwijderen**

Je kunt met Aspose.Slides de schrijfbeveiliging van een presentatiebestand verwijderen. Zo kunnen gebruikers naar wens wijzigen—en krijgen ze geen waarschuwingen bij het uitvoeren van zulke handelingen.

Je kunt de schrijfbeveiliging van een presentatie verwijderen door de [RemoveWriteProtection](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50)‑methode te gebruiken. Deze voorbeeldcode toont hoe je de schrijfbeveiliging van een presentatie verwijdert:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Eigenschappen van een versleutelde presentatie ophalen**

Meestal hebben gebruikers moeite om de documenteigenschappen van een versleutelde of met een wachtwoord beveiligde presentatie op te halen. Aspose.Slides biedt echter een mechanisme waarmee je een presentatie met een wachtwoord kunt beveiligen en toch toegang tot de documenteigenschappen behoudt.

**Opmerking:** Standaard zijn de documenteigenschappen van een presentatie ook met een wachtwoord beveiligd wanneer Aspose.Slides een presentatie versleutelt. Als je de documenteigenschappen toegankelijk wilt houden zelfs na versleuteling, biedt Aspose.Slides precies die mogelijkheid.

Als je wilt dat gebruikers de mogelijkheid behouden om de eigenschappen van een versleutelde presentatie te bekijken, geef dan `false` door aan de `set_EncryptDocumentProperties`‑methode van [IProtectionManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iprotectionmanager/). Deze voorbeeldcode toont hoe je een presentatie versleutelt en toch gebruikers toegang geeft tot de documenteigenschappen:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Alleen documenteigenschappen laden van een versleutelde presentatie**

Om de metadata van een versleutelde presentatie te inspecteren zonder de dia's of andere inhoud te laden, maak je een [LoadOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/)‑object aan en stel je [set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) in op `true`. In deze modus negeert Aspose.Slides het wachtwoord en laadt alleen de publiek toegankelijke documenteigenschappen.

De volgende codevoorbeelden lezen ingebouwde en aangepaste documenteigenschappen via [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/get_documentproperties/):

``` cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);
auto documentProperties = presentation->get_DocumentProperties();

// Read built-in document properties.
auto title = documentProperties->get_Title();
auto author = documentProperties->get_Author();
Console::WriteLine(String(u"Title: ") + title);
Console::WriteLine(String(u"Author: ") + author);

// Read custom document properties.
int customPropertyCount = documentProperties->get_CountOfCustomProperties();

for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    auto propertyName = documentProperties->GetCustomPropertyName(propertyIndex);
    auto propertyValue = documentProperties->idx_get(propertyName);
    auto propertyValueText = ObjectExt::ToString(propertyValue);

    Console::WriteLine(propertyName + u": " + propertyValueText);
}

presentation->Dispose();
```

Deze workflow werkt alleen wanneer de documenteigenschappen onversleuteld (publiek) zijn gelaten toen de presentatie werd versleuteld. Als de documenteigenschappen versleuteld zijn, leidt het instellen van `LoadOptions::set_OnlyLoadDocumentProperties` op `true` tot een uitzondering omdat het wachtwoord in deze modus wordt genegeerd. Om versleutelde documenteigenschappen te benaderen of de complete presentatie, inclusief dia's en andere inhoud, te laden, geef je het juiste wachtwoord mee met `LoadOptions::set_Password` in [LoadOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/).

## **Controleren of een presentatie met een wachtwoord is beveiligd**

Voordat je een presentatie laadt, wil je misschien controleren en bevestigen dat de presentatie niet met een wachtwoord is beveiligd. Zo kun je fouten en soortgelijke problemen vermijden die ontstaan wanneer een met een wachtwoord beveiligde presentatie zonder wachtwoord wordt geladen.

Deze C++‑code toont hoe je een presentatie kunt onderzoeken om te zien of deze met een wachtwoord is beveiligd (zonder de presentatie zelf te laden):

```c++
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **Controleren of een presentatie versleuteld is**

Aspose.Slides stelt je in staat te controleren of een presentatie versleuteld is. Hiervoor kun je de [get_IsEncrypted()](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68)‑methode gebruiken, die `true` retourneert als de presentatie versleuteld is en `false` als de presentatie niet versleuteld is. 

Deze voorbeeldcode toont hoe je kunt controleren of een presentatie versleuteld is:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **Controleren of een presentatie schrijfbeveiligd is**

Aspose.Slides stelt je in staat te controleren of een presentatie schrijfbeveiligd is. Hiervoor kun je de [get_IsWriteProtected()](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2)‑methode gebruiken, die `true` retourneert als de presentatie schrijfbeveiligd is en `false` als de presentatie niet schrijfbeveiligd is. 

Deze voorbeeldcode toont hoe je kunt controleren of een presentatie schrijfbeveiligd is:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **Controleren of een presentatiewachtwoord wordt gebruikt**

Je wilt wellicht controleren en bevestigen dat een specifiek wachtwoord is gebruikt om een presentatiedocument te beveiligen. Aspose.Slides biedt de mogelijkheid om een wachtwoord te valideren. 

Deze voorbeeldcode toont hoe je een wachtwoord valideert:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// controleer of "pass" overeenkomt met
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

Het retourneert `true` als de presentatie is versleuteld met het opgegeven wachtwoord. Anders retourneert het `false`. 

{{% alert color="info" title="Zie ook" %}} 
- [Digital Signature in PowerPoint](/slides/nl/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Welke versleutelingsmethoden worden ondersteund door Aspose.Slides?**

Aspose.Slides ondersteunt moderne versleutelingsmethoden, waaronder AES‑gebaseerde algoritmen, wat een hoog niveau van gegevensbeveiliging voor je presentaties garandeert.

**Wat gebeurt er als een onjuist wachtwoord wordt ingevoerd bij het proberen een presentatie te openen?**

Er wordt een uitzondering gegooid als een onjuist wachtwoord wordt gebruikt, waarmee je wordt gewaarschuwd dat de toegang tot de presentatie wordt geweigerd. Dit helpt ongeautoriseerde toegang te voorkomen en beschermt de inhoud van de presentatie.

**Zijn er prestatie‑implicaties bij het werken met met een wachtwoord beveiligde presentaties?**

Het versleutelings‑ en ontsleutelingsproces kan enige extra overhead veroorzaken tijdens open‑ en opslaan‑bewerkingen. In de meeste gevallen is deze prestatie‑impact minimaal en heeft ze geen significante invloed op de totale verwerkingstijd van je presentatietaken.