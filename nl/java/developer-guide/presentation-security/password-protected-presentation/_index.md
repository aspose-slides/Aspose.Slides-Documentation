---
title: Presentaties beveiligen met wachtwoord in Java
linktitle: Wachtwoordbeveiliging
type: docs
weight: 20
url: /nl/java/password-protected-presentation/
keywords:
- wachtwoordbeveiligde presentatie
- openingswachtwoord
- PowerPoint versleutelen
- PowerPoint ontsleutelen
- presentatiewachtwoord valideren
- presentatiewachtwoord controleren
- versleutelde presentatie openen
- versleuteling verwijderen
- PowerPoint
- PPT
- PPTX
- presentatie
- Java
- Aspose.Slides
description: "Versleutel, detecteer, valideer, open en ontcijfer wachtwoordbeveiligde PowerPoint PPT- en PPTX-presentaties in Java met Aspose.Slides."
---
## **Overzicht**

Een openingswachtwoord versleutelt een presentatie. Het juiste wachtwoord is vereist om de presentatie-inhoud te laden en weer te geven, zodat deze bescherming vertrouwelijkheid biedt.

Een openingswachtwoord verschilt van een schrijfbeschermingswachtwoord. Schrijfbescherming beperkt bewerking maar versleutelt de inhoud niet en verhindert niet dat de presentatie wordt geladen. Zie voor het beheren van wachtwoorden voor het aanpassen van presentaties [Write-Protect Presentations](/slides/nl/java/write-protected-presentation/).

De onderstaande werkstromen gelden voor zowel PPT‑ als PPTX‑presentaties. De voorbeelden gebruiken beide formaten wanneer hun gedrag op bestands‑ en streambasis van belang is.

## **Een presentatie versleutelen met een openingswachtwoord**

Gebruik [IProtectionManager.encrypt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) om een openingswachtwoord toe te wijzen. Gebruik vervolgens [IPresentation.save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) om de versleutelde presentatie op te slaan.

Het volgende voorbeeld versleutelt een PPTX‑presentatie:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Documenteigenschappen openbaar houden**

Standaard neemt Aspose.Slides documenteigenschappen op in de versleuteling van een presentatie. De methode [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) regelt dit gedrag onafhankelijk van de versleuteling van de dia‑inhoud. Geef `false` door vóór het aanroepen van [IProtectionManager.encrypt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) wanneer een indexeer‑, classificatie‑, zoek‑ of document‑beheersysteem metadata moet kunnen lezen zonder het openingswachtwoord.

Het volgende voorbeeld maakt een versleutelde PPTX‑presentatie terwijl de ingebouwde documenteigenschappen openbaar blijven:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    IDocumentProperties properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`false` doorgeven aan [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) maakt niet de dia’s, masters, lay‑outs, vormen, media of andere presentatie‑inhoud openbaar. Het heeft alleen invloed op documenteigenschappen. Zie [Manage Presentation Properties](/slides/nl/java/presentation-properties/) om die eigenschappen te lezen zonder de versleutelde inhoud te laden.

## **Een versleutelde presentatie laden**

Stel [ILoadOptions.setPassword](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) in op het openingswachtwoord en geef de opties door aan [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) bij het laden van het bestand. Laden mislukt wanneer een openingswachtwoord nodig is maar het opgegeven wachtwoord ontbreekt of onjuist is.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Werk met de ontcijferde presentatie.
} finally {
    presentation.dispose();
}
```

## **Versleuteling van een presentatie verwijderen**

Laad de presentatie met het openingswachtwoord, roep [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iprotectionmanager/#removeEncryption--) aan en sla het resultaat op. De opgeslagen presentatie kan vervolgens zonder wachtwoord worden geladen.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Een openingswachtwoord valideren vóór het laden**

Gebruik [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) om een [IPresentationInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentationinfo/) te verkrijgen zonder een volledige presentatie‑instance te maken. Controleer [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) voordat u een wachtwoord vraagt of valideert. Wanneer bescherming aanwezig is, valideer de opgegeven waarde met [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-).

### **Bestandspad‑werkstroom**

Het volgende voorbeeld valideert een openingswachtwoord voor een PPTX‑bestand, geeft de gevalideerde waarde door aan [ILoadOptions.setPassword](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-), en laadt vervolgens de volledige presentatie:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;

String filePath = "protected-presentation.pptx";
String password = "open_password";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    System.out.println("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    System.out.println("The opening password is incorrect.");
} else {
    LoadOptions loadOptions = new LoadOptions();
    loadOptions.setPassword(password);

    Presentation presentation = new Presentation(filePath, loadOptions);
    try {
        System.out.println("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **Stream‑werkstroom**

De stream‑overload van [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) biedt dezelfde werkstroom. Reset de positie van een seek‑bare stream voordat u de volledige presentatie uit die stream laadt.

Het volgende voorbeeld gebruikt een PPT‑bestand:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import java.io.FileInputStream;

String password = "open_password";

FileInputStream presentationStream = new FileInputStream("protected-presentation.ppt");
try {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(presentationStream);

    if (!presentationInfo.isPasswordProtected()) {
        System.out.println("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        System.out.println("The opening password is incorrect.");
    } else {
        presentationStream.getChannel().position(0);

        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setPassword(password);

        Presentation presentation = new Presentation(presentationStream, loadOptions);
        try {
            System.out.println("The presentation was validated and loaded successfully.");
        } finally {
            presentation.dispose();
        }
    }
} finally {
    presentationStream.close();
}
```

### **Returnwaarden van checkPassword**

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) retourneert `true` alleen wanneer de presentatie een openingswachtwoord heeft en het opgegeven wachtwoord correct is. Het retourneert `false` in elk van de volgende gevallen:

- Het wachtwoord is onjuist.
- De presentatie heeft geen openingswachtwoord.
- Het opgegeven wachtwoord is `null` of leeg.

Het gedrag is hetzelfde voor PPT‑ en PPTX‑presentaties.

## **Controleren of een geladen presentatie versleuteld is**

Na het laden van een presentatie met het juiste wachtwoord, inspecteer [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iprotectionmanager/#isEncrypted--) om te bevestigen dat de bronpresentatie versleuteld was. Om bescherming door een openingswachtwoord vóór het laden te detecteren, gebruik `IPresentationInfo.isPasswordProtected` zoals hierboven getoond.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
    System.out.println("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **Beveiligingsaanbevelingen**

{{% alert color="warning" title="Security" %}}
Log geen openingswachtwoorden en voeg ze niet toe aan diagnostische berichten. Vermijd onnodige herhaalde validatie‑pogingen, bewaar wachtwoorden in het geheugen slechts zolang als nodig is, en hergebruik een succesvolle validatie‑resultaat bij het direct laden van de presentatie.

Open documenteigenschappen kunnen auteursnamen, titels, onderwerpen, trefwoorden, bedrijfsinformatie, opmerkingen en aangepaste waarden onthullen, zelfs wanneer de presentatie‑inhoud versleuteld is. Versleutel gevoelige metadata samen met de presentatie. Het openbaar houden van eigenschappen moet een expliciete beslissing zijn, alleen wanneer systemen de file moeten indexeren, classificeren, zoeken of beheren zonder een openingswachtwoord.
{{% /alert %}}

## **Een presentatie online met een wachtwoord beveiligen**

1. Open de applicatie [Aspose.Slides Lock](https://products.aspose.app/slides/nl/lock).
1. Selecteer of upload de presentatie.
1. Voer een wachtwoord in voor weergave‑bescherming.
1. Voer eventueel een apart wachtwoord in voor bewerkings‑bescherming.
1. Pas de bescherming toe en download het resulterende bestand.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/nl/java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/nl/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Wat is het verschil tussen een openingswachtwoord en een schrijfbeschermingswachtwoord?**

Een openingswachtwoord versleutelt de presentatie en is vereist om de inhoud te laden. Een schrijfbeschermingswachtwoord beperkt bewerking zonder de inhoud te versleutelen.

**Kan ik een openingswachtwoord valideren zonder alle dia’s te laden?**

Ja. Verkrijg presentatiedetails, controleer of er een openingswachtwoordbescherming aanwezig is, en valideer het wachtwoord voordat u een volledige presentatie‑instance maakt.

**Kan een applicatie metadata lezen zonder het openingswachtwoord?**

Ja, maar alleen wanneer de presentatie versleuteld is met uitgeschakelde document‑eigenschap‑versleuteling. De applicatie moet dan de alleen‑document‑eigenschappen‑laadmodus gebruiken die beschreven staat in [Manage Presentation Properties](/slides/nl/java/presentation-properties/).

**Ondersteunen de wachtwoord‑check‑werkstromen zowel PPT als PPTX?**

Ja. Detectie en validatie van wachtwoorden op bestands‑ of streambasis werken identiek voor PPT‑ en PPTX‑presentaties.