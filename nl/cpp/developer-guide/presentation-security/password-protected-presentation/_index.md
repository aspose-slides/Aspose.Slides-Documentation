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
- schrijfbescherming
- PowerPoint-beveiliging
- presentatiebeveiliging
- wachtwoord verwijderen
- beveiliging verwijderen
- versleuteling verwijderen
- wachtwoord uitschakelen
- beveiliging uitschakelen
- schrijfbescherming verwijderen
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe je moeiteloos wachtwoordbeveiligde PowerPoint- en OpenDocument-presentaties kunt vergrendelen en ontgrendelen met Aspose.Slides voor C++. Beveilig je presentaties."
---
## **Introductie**

Wanneer je een presentatie met een wachtwoord beveiligt, stel je een wachtwoord in dat bepaalde beperkingen afdwingt op de presentatie. Om de beperkingen te verwijderen moet het wachtwoord worden ingevoerd. Een met een wachtwoord beveiligde presentatie wordt beschouwd als een vergrendelde presentatie.

Gewoonlijk kun je een wachtwoord instellen om deze beperkingen op een presentatie af te dwingen:

- **Aanpassing**

  Als je wilt dat alleen bepaalde gebruikers je presentatie kunnen aanpassen, kun je een wijzigingsbeperking instellen. Deze beperking voorkomt dat mensen de inhoud van je presentatie wijzigen, aanpassen of kopiëren (behalve als ze het wachtwoord invoeren). 

  Echter, in dit geval kan een gebruiker, zelfs zonder wachtwoord, je document wel openen. In deze alleen‑leesmodus kan de gebruiker de inhoud – hyperlinks, animaties, effecten en andere elementen – van je presentatie bekijken, maar hij kan geen items kopiëren of de presentatie opslaan. 

- **Openen**

  Als je wilt dat alleen bepaalde gebruikers je presentatie kunnen openen, kun je een openingsbeperking instellen. Deze beperking voorkomt dat mensen de inhoud van je presentatie kunnen bekijken (behalve als ze het wachtwoord invoeren).

  Technisch gezien voorkomt de openingsbeperking ook dat gebruikers je presentatie wijzigen: als mensen een presentatie niet kunnen openen, kunnen ze deze niet aanpassen of veranderen. 
  
  **Let op** dat wanneer je een presentatie met een wachtwoord beveiligt om openen te voorkomen, het presentiebestand versleuteld wordt.

## **Hoe je online een presentatie met een wachtwoord beveiligt**

1. Ga naar onze [**Aspose.Slides Lock**](https://products.aspose.app/slides/nl/lock)-pagina. 

   ![todo:image_alt_text](slides-lock.png)

2. Klik op **Sleep of upload je bestanden**.

3. Selecteer het bestand dat je wilt beveiligen met een wachtwoord op je computer. 

4. Voer je voorkeurswachtwoord in voor bewerkingsbeveiliging; voer je voorkeurswachtwoord in voor weergavebeveiliging. 

5. Als je wilt dat gebruikers je presentatie als definitieve kopie zien, vink dan het **Mark as final**‑vakje aan.

6. Klik op **BEVEILIG NU**. 

7. Klik op **DOWNLOAD NU**.

## **Wachtwoordbeveiliging voor presentaties in Aspose.Slides**
**Ondersteunde formaten**

Aspose.Slides ondersteunt wachtwoordbeveiliging, versleuteling en soortgelijke bewerkingen voor presentaties in deze formaten: 

- PPTX en PPT - Microsoft PowerPoint‑presentatie 
- ODP - OpenDocument‑presentatie 
- OTP - OpenDocument‑presentatiesjabloon 

**Ondersteunde bewerkingen**

Aspose.Slides laat je wachtwoordbeveiliging gebruiken op presentaties om wijzigingen te voorkomen op de volgende manieren:

- Een presentatie versleutelen
- Een schrijfbescherming instellen voor een presentatie

**Andere bewerkingen**

Aspose.Slides laat je andere taken uitvoeren met betrekking tot wachtwoordbeveiliging en versleuteling op de volgende manieren:

- Een presentatie ontsleutelen; een versleutelde presentatie openen
- Versleuteling verwijderen; wachtwoordbeveiliging uitschakelen
- Schrijfbescherming van een presentatie verwijderen
- De eigenschappen van een versleutelde presentatie ophalen
- Controleren of een presentatie versleuteld is
- Controleren of een presentatie met een wachtwoord is beveiligd.

## **Een presentatie versleutelen**

Je kunt een presentatie versleutelen door een wachtwoord in te stellen. Om vervolgens de vergrendelde presentatie te wijzigen, moet een gebruiker het wachtwoord invoeren. 

Om een presentatie te versleutelen of te beveiligen met een wachtwoord, moet je de encrypt‑methode gebruiken (van [ProtectionManager](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.protection_manager)) om een wachtwoord voor de presentatie in te stellen. Je geeft het wachtwoord door aan de encrypt‑methode en gebruikt de save‑methode om de nu versleutelde presentatie op te slaan. 

Deze voorbeeldcode laat zien hoe je een presentatie versleutelt:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Schrijfbescherming instellen voor een presentatie** 

Je kunt een markering toevoegen met de tekst “Do not modify” aan een presentatie. Zo kun je gebruikers duidelijk maken dat ze geen wijzigingen mogen aanbrengen.  

**Let op** dat het proces van schrijfbescherming de presentatie niet versleutelt. Daarom kunnen gebruikers, als ze willen, de presentatie wel wijzigen, maar om de wijzigingen op te slaan moeten ze een presentatie met een andere naam aanmaken. 

Om een schrijfbescherming in te stellen, moet je de setWriteProtection‑methode gebruiken. Deze voorbeeldcode laat zien hoe je een schrijfbescherming aan een presentatie toevoegt:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Een versleutelde presentatie laden**

Aspose.Slides laat je een versleuteld bestand laden door het wachtwoord door te geven. Om een presentatie te ontsleutelen, moet je de [RemoveEncryption](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d)‑methode aanroepen zonder parameters. Vervolgens moet je het juiste wachtwoord invoeren om de presentatie te laden. 

Deze voorbeeldcode laat zien hoe je een presentatie ontsleutelt: 

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// werk met ontcijferde presentatie
```

## **Versleuteling uit een presentatie verwijderen**

Je kunt de versleuteling of wachtwoordbeveiliging van een presentatie verwijderen. Hierdoor kunnen gebruikers de presentatie zonder beperkingen openen of aanpassen. 

Om versleuteling of wachtwoordbeveiliging te verwijderen, moet je de [RemoveEncryption](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d)‑methode aanroepen. Deze voorbeeldcode laat zien hoe je de versleuteling uit een presentatie verwijdert:

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Schrijfbescherming van een presentatie verwijderen**

Je kunt met Aspose.Slides de schrijfbescherming op een presentatiedocument verwijderen. Zo kunnen gebruikers naar wens aanpassen — zonder waarschuwingen.

Je kunt de schrijfbescherming van een presentatie verwijderen met de [RemoveWriteProtection](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50)‑methode. Deze voorbeeldcode laat zien hoe je de schrijfbescherming van een presentatie verwijdert:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Eigenschappen van een versleutelde presentatie ophalen**

Gewoonlijk hebben gebruikers moeite om de documenteigenschappen van een versleutelde of met wachtwoord beveiligde presentatie op te halen. Aspose.Slides biedt echter een mechanisme waarmee je een presentatie met een wachtwoord kunt beveiligen en tegelijk toegang tot de documenteigenschappen behoudt.

**Let op:** standaard worden bij het versleutelen van een presentatie door Aspose.Slides ook de documenteigenschappen met een wachtwoord beveiligd. Als je de documenteigenschappen zelfs na versleuteling toegankelijk wilt maken, biedt Aspose.Slides die mogelijkheid.

Als je wilt dat gebruikers de mogelijkheid behouden om de eigenschappen van een versleutelde presentatie te bekijken, geef dan `false` door aan de `set_EncryptDocumentProperties`‑methode van [IProtectionManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iprotectionmanager/). Deze voorbeeldcode laat zien hoe je een presentatie versleutelt en toch gebruikers toegang tot de documenteigenschappen geeft:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Alleen documenteigenschappen laden uit een versleutelde presentatie**

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

Deze workflow werkt alleen wanneer de documenteigenschappen onbeveiligd (publiek) bleven toen de presentatie werd versleuteld. Als de documenteigenschappen versleuteld zijn, leidt het instellen van `LoadOptions::set_OnlyLoadDocumentProperties` op `true` tot een uitzondering omdat het wachtwoord in deze modus wordt genegeerd. Om versleutelde documenteigenschappen te benaderen of de volledige presentatie (inclusief dia's en andere inhoud) te laden, geef je het juiste wachtwoord door met `LoadOptions::set_Password` in [LoadOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/).

## **Controleren of een presentatie met een wachtwoord is beveiligd**

Voordat je een presentatie laadt, wil je wellicht controleren of de presentatie niet met een wachtwoord is beveiligd. Zo kun je fouten en soortgelijke problemen vermijden die ontstaan wanneer een met wachtwoord beveiligde presentatie zonder wachtwoord wordt geladen.

Deze C++‑code laat zien hoe je een presentatie kunt onderzoeken om te zien of deze met een wachtwoord is beveiligd (zonder de presentatie zelf te laden):

```c++
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **Controleren of een presentatie versleuteld is**

Aspose.Slides stelt je in staat te controleren of een presentatie versleuteld is. Hiervoor kun je de [get_IsEncrypted()](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68)‑methode gebruiken, die `true` teruggeeft als de presentatie versleuteld is, of `false` als deze niet versleuteld is. 

Deze voorbeeldcode laat zien hoe je kunt controleren of een presentatie versleuteld is:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **Controleren of een presentatie schrijfbeschermd is**

Aspose.Slides laat je controleren of een presentatie schrijfbeschermd is. Hiervoor kun je de [get_IsWriteProtected()](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2)‑methode gebruiken, die `true` retourneert als de presentatie versleuteld is of `false` als deze niet versleuteld is. 

Deze voorbeeldcode laat zien hoe je kunt controleren of een presentatie schrijfbeschermd is:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **Verifiëren van wachtwoordgebruik van presentatie**

Je wilt wellicht controleren of een specifiek wachtwoord is gebruikt om een presentatiedocument te beveiligen. Aspose.Slides biedt de mogelijkheid een wachtwoord te valideren. 

Deze voorbeeldcode laat zien hoe je een wachtwoord valideert:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// controleer of "pass" overeenkomt met
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

Het retourneert `true` als de presentatie versleuteld is met het opgegeven wachtwoord. Anders retourneert het `false`. 

{{% alert color="primary" title="Zie ook" %}} 
- [Digital Signature in PowerPoint](/slides/nl/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Veelgestelde vragen**

**Welke encryptiemethoden ondersteunt Aspose.Slides?**

Aspose.Slides ondersteunt moderne encryptiemethoden, waaronder op AES gebaseerde algoritmen, waardoor een hoog beveiligingsniveau voor je presentaties wordt gegarandeerd.

**Wat gebeurt er als een onjuist wachtwoord wordt ingevoerd bij het proberen te openen van een presentatie?**

Er wordt een uitzondering gegooid bij een onjuist wachtwoord, waardoor je wordt gewaarschuwd dat de toegang tot de presentatie wordt geweigerd. Dit helpt ongeautoriseerde toegang te voorkomen en beschermt de inhoud van de presentatie.

**Hebben wachtwoordbeveiligde presentaties invloed op de prestaties?**

Het versleutelings- en ontsleutelingsproces kan een lichte overhead veroorzaken tijdens het openen en opslaan. In de meeste gevallen is deze impact minimaal en heeft het geen significante invloed op de algehele verwerkingstijd van je presentatietaken.