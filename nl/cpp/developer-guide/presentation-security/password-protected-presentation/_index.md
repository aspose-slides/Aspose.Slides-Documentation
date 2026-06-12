---
title: Beveilig presentaties met wachtwoorden in C++
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
description: "Leer hoe u moeiteloos PowerPoint- en OpenDocument‑presentaties met wachtwoordbeveiliging kunt vergrendelen en ontgrendelen met Aspose.Slides voor C++. Beveilig uw presentaties."
---
## **Introductie**

Wanneer u een presentatie met een wachtwoord beveiligt, betekent dit dat u een wachtwoord instelt dat bepaalde beperkingen op de presentatie afdwingt. Om de beperkingen te verwijderen, moet het wachtwoord worden ingevoerd. Een met wachtwoord beveiligde presentatie wordt beschouwd als een vergrendelde presentatie.

Typisch kunt u een wachtwoord instellen om deze beperkingen op een presentatie af te dwingen:

- **Wijziging**

  Als u alleen bepaalde gebruikers uw presentatie wilt laten wijzigen, kunt u een wijzigingsbeperking instellen. Deze beperking voorkomt dat mensen wijzigen, veranderen of kopiëren in uw presentatie (tenzij ze het wachtwoord invoeren).

  Echter, in dit geval kan een gebruiker, zelfs zonder het wachtwoord, toegang krijgen tot uw document en het openen. In de alleen-lezen modus kan de gebruiker de inhoud of zaken—hyperlinks, animaties, effecten en andere—binnen uw presentatie bekijken, maar hij kan geen items kopiëren of de presentatie opslaan.

- **Openen**

  Als u alleen bepaalde gebruikers uw presentatie wilt laten openen, kunt u een openingsbeperking instellen. Deze beperking voorkomt dat mensen zelfs de inhoud van uw presentatie kunnen bekijken (tenzij ze het wachtwoord invoeren).

  Technisch gezien voorkomt de openingsbeperking ook dat gebruikers uw presentaties wijzigen: wanneer mensen een presentatie niet kunnen openen, kunnen ze deze niet wijzigen of aanpassingen maken.

  **Note** dat wanneer u een presentatie met een wachtwoord beveiligt om openen te voorkomen, het presentatie‑bestand versleuteld wordt.

## **Hoe een presentatie online met wachtwoord beveiligen**

1. Ga naar onze [**Aspose.Slides Lock**](https://products.aspose.app/slides/nl/lock) pagina. 

   ![todo:image_alt_text](slides-lock.png)

2. Klik op **Sleep of upload uw bestanden**.

3. Selecteer het bestand dat u wilt beveiligen met een wachtwoord op uw computer. 

4. Voer uw gewenste wachtwoord in voor bewerkingsbeveiliging; Voer uw gewenste wachtwoord in voor weergavebeveiliging. 

5. Als u wilt dat gebruikers uw presentatie zien als de definitieve kopie, vink dan het **Mark as final** selectievakje aan.

6. Klik op **PROTECT NOW.** 

7. Klik op **DOWNLOAD NOW.**

## **Wachtwoordbeveiliging voor presentaties in Aspose.Slides**
**Ondersteunde formaten**

Aspose.Slides ondersteunt wachtwoordbeveiliging, versleuteling en vergelijkbare bewerkingen voor presentaties in deze formaten:

- PPTX en PPT - Microsoft PowerPoint‑presentatie
- ODP - OpenDocument‑presentatie
- OTP - OpenDocument‑presentatiesjabloon

**Ondersteunde bewerkingen**

Aspose.Slides stelt u in staat wachtwoordbeveiliging op presentaties te gebruiken om wijzigingen te voorkomen op de volgende manieren:

- Een presentatie versleutelen
- Schrijfbescherming instellen voor een presentatie

**Andere bewerkingen**

Aspose.Slides laat u andere taken uitvoeren die verband houden met wachtwoordbeveiliging en versleuteling op de volgende manieren:

- Een presentatie ontsleutelen; een versleutelde presentatie openen
- Versleuteling verwijderen; wachtwoordbeveiliging uitschakelen
- Schrijfbescherming van een presentatie verwijderen
- De eigenschappen van een versleutelde presentatie ophalen
- Controleren of een presentatie versleuteld is
- Controleren of een presentatie met wachtwoord is beveiligd.

## **Een presentatie versleutelen**

U kunt een presentatie versleutelen door een wachtwoord in te stellen. Vervolgens moet een gebruiker het wachtwoord invoeren om de vergrendelde presentatie te wijzigen.

Om een presentatie te versleutelen of met een wachtwoord te beveiligen, moet u de **encrypt**‑methode gebruiken (van [ProtectionManager](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.protection_manager)) om een wachtwoord voor de presentatie in te stellen. U geeft het wachtwoord door aan de **encrypt**‑methode en gebruikt vervolgens de **save**‑methode om de nu versleutelde presentatie op te slaan.

Deze voorbeeldcode laat zien hoe u een presentatie versleutelt:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Schrijfbescherming instellen voor een presentatie** 

U kunt een markering “Do not modify” toevoegen aan een presentatie. Op deze manier laat u gebruikers weten dat u niet wilt dat zij wijzigingen aanbrengen in de presentatie.  

**Note** dat het proces van schrijfbescherming de presentatie niet versleutelt. Daarom kunnen gebruikers—indien ze dat willen—de presentatie wijzigen, maar om de wijzigingen op te slaan, moeten ze een presentatie onder een andere naam aanmaken. 

Om schrijfbescherming in te stellen, moet u de **setWriteProtection**‑methode gebruiken. Deze voorbeeldcode laat zien hoe u schrijfbescherming instelt voor een presentatie:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Een versleutelde presentatie laden**

Aspose.Slides maakt het mogelijk een versleuteld bestand te laden door het wachtwoord door te geven. Om een presentatie te ontsleutelen, moet u de [RemoveEncryption](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d)‑methode zonder parameters aanroepen. Vervolgens moet u het juiste wachtwoord invoeren om de presentatie te laden. 

Deze voorbeeldcode laat zien hoe u een presentatie ontsleutelt: 

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// werk met ontsleutelde presentatie
```

## **Versleuteling verwijderen van een presentatie**

U kunt de versleuteling of wachtwoordbeveiliging van een presentatie verwijderen. Op deze manier kunnen gebruikers de presentatie zonder beperkingen openen of wijzigen. 

Om versleuteling of wachtwoordbeveiliging te verwijderen, moet u de [RemoveEncryption](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d)‑methode aanroepen. Deze voorbeeldcode laat zien hoe u versleuteling van een presentatie verwijdert:

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Schrijfbescherming verwijderen van een presentatie**

U kunt Aspose.Slides gebruiken om de schrijfbescherming van een presentatiedocument te verwijderen. Op die manier kunnen gebruikers vrijelijk wijzigen en krijgen zij geen waarschuwingen bij dergelijke handelingen.

U kunt de schrijfbescherming van een presentatie verwijderen met de [RemoveWriteProtection](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50)‑methode. Deze voorbeeldcode laat zien hoe u de schrijfbescherming van een presentatie verwijdert:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **De eigenschappen van een versleutelde presentatie ophalen**

Gebruikers hebben vaak moeite om de documenteigenschappen van een versleutelde of met wachtwoord beveiligde presentatie te verkrijgen. Aspose.Slides biedt echter een mechanisme waarmee u een presentatie kunt beveiligen met een wachtwoord terwijl gebruikers nog steeds toegang hebben tot de eigenschappen van die presentatie.

**Note** dat wanneer Aspose.Slides een presentatie versleutelt, de documenteigenschappen van de presentatie standaard ook met een wachtwoord worden beveiligd. Als u echter de eigenschappen van de presentatie toegankelijk wilt maken (zelfs nadat de presentatie versleuteld is), maakt Aspose.Slides dit mogelijk.

Als u wilt dat gebruikers de mogelijkheid behouden om de eigenschappen van een door u versleutelde presentatie te bekijken, kunt u `true` doorgeven aan de [set_EncryptDocumentProperties()](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.protection_manager#a67e041b432552969d106f72fa7fe5a1d)‑methode. Deze voorbeeldcode laat zien hoe u een presentatie versleutelt en tegelijkertijd gebruikers toestaat de documenteigenschappen te bekijken:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(true);
presentation->get_ProtectionManager()->Encrypt(u"123123");
```

## **Controleren of een presentatie met wachtwoord is beveiligd**

Voordat u een presentatie laadt, wilt u mogelijk controleren of de presentatie niet met een wachtwoord is beveiligd. Op die manier kunt u fouten en soortgelijke problemen voorkomen die ontstaan wanneer een met wachtwoord beveiligde presentatie zonder wachtwoord wordt geladen.

Deze C++‑code laat zien hoe u een presentatie onderzoekt om te bepalen of deze met wachtwoord beveiligd is (zonder de presentatie zelf te laden):

```c++
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **Controleren of een presentatie versleuteld is**

Aspose.Slides maakt het mogelijk te controleren of een presentatie versleuteld is. Hiervoor kunt u de [get_IsEncrypted()](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68)‑methode gebruiken, die `true` retourneert als de presentatie versleuteld is of `false` als deze niet versleuteld is. 

Deze voorbeeldcode laat zien hoe u controleert of een presentatie versleuteld is:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **Controleren of een presentatie schrijfbeschermd is**

Aspose.Slides maakt het mogelijk te controleren of een presentatie schrijfbeschermd is. Hiervoor kunt u de [get_IsWriteProtected()](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2)‑methode gebruiken, die `true` retourneert als de presentatie schrijfbeschermd is of `false` als deze niet schrijfbeschermd is. 

Deze voorbeeldcode laat zien hoe u controleert of een presentatie schrijfbeschermd is:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **Verifiëren van wachtwoordgebruik voor presentatie**

U wilt wellicht controleren of een specifiek wachtwoord is gebruikt om een presentatiedocument te beveiligen. Aspose.Slides biedt de mogelijkheid om een wachtwoord te valideren. 

Deze voorbeeldcode laat zien hoe u een wachtwoord valideert:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// controleer of "pass" overeenkomt met
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

Het retourneert `true` als de presentatie versleuteld is met het opgegeven wachtwoord. Anders retourneert het `false`. 

{{% alert color="primary" title="Zie ook" %}} 
- [Digitale handtekening in PowerPoint](/slides/nl/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Welke versleutelingsmethoden ondersteunt Aspose.Slides?**

Aspose.Slides ondersteunt moderne versleutelingsmethoden, inclusief AES‑gebaseerde algoritmen, wat zorgt voor een hoog beveiligingsniveau van uw presentaties.

**Wat gebeurt er als er een onjuist wachtwoord wordt ingevoerd bij het proberen te openen van een presentatie?**

Er wordt een uitzondering gegooid bij een onjuist wachtwoord, waardoor u wordt gewaarschuwd dat de toegang tot de presentatie wordt geweigerd. Dit helpt onbevoegde toegang te voorkomen en beschermt de inhoud van de presentatie.

**Zijn er prestatie‑implicaties bij het werken met met wachtwoord beveiligde presentaties?**

Het versleutel‑ en ontsleutelproces kan een lichte overhead veroorzaken tijdens het openen en opslaan. In de meeste gevallen is deze impact minimaal en beïnvloedt het de algehele verwerkingstijd van uw presentatietaken niet wezenlijk.