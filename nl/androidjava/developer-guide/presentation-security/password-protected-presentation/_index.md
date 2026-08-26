---
title: Presentaties beveiligen met wachtwoord op Android
linktitle: Wachtwoordbeveiliging
type: docs
weight: 20
url: /nl/androidjava/password-protected-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Versleutel, detecteer, valideer, open en ontsleutel wachtwoordbeveiligde PowerPoint PPT- en PPTX-presentaties met Aspose.Slides voor Android via Java."
---
## **Overzicht**

Een openingswachtwoord versleutelt een presentatie. Het correcte wachtwoord is vereist om de presentatieinhoud te laden en te bekijken, zodat deze bescherming vertrouwelijkheid biedt.

Een openingswachtwoord verschilt van een schrijfbeschermingswachtwoord. Schrijfbescherming beperkt wijzigingen, maar versleutelt de inhoud niet en verhindert niet dat de presentatie wordt geladen. Zie [Write-Protect Presentations](/slides/nl/androidjava/write-protected-presentation/) om wachtwoorden voor het wijzigen van presentaties te beheren.

De onderstaande werkstromen zijn van toepassing op zowel PPT- als PPTX‑presentaties. De voorbeelden gebruiken beide formaten wanneer hun bestand‑gebaseerde en stream‑gebaseerde gedrag belangrijk is.

## **Een presentatie versleutelen met een openingswachtwoord**

Gebruik [IProtectionManager.encrypt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) om een openingswachtwoord toe te wijzen. Gebruik vervolgens [IPresentation.save](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) om de versleutelde presentatie op te slaan.

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

## **Een versleutelde presentatie laden**

Stel [ILoadOptions.setPassword](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) in op het openingswachtwoord en geef de opties door aan [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) bij het laden van het bestand. Laden mislukt wanneer een openingswachtwoord vereist is maar het opgegeven wachtwoord ontbreekt of onjuist is.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Werk met de ontsleutelde presentatie.
} finally {
    presentation.dispose();
}
```

## **Versleuteling van een presentatie verwijderen**

Laad de presentatie met het bijbehorende openingswachtwoord, roep [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iprotectionmanager/#removeEncryption--) aan en sla het resultaat op. De opgeslagen presentatie kan daarna zonder wachtwoord worden geladen.

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

Gebruik [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) om [IPresentationInfo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationinfo/) te verkrijgen zonder een volledige presentatietoestand aan te maken. Controleer [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) voordat u een wachtwoord opvraagt of valideert. Wanneer bescherming aanwezig is, valideer dan de opgegeven waarde met [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-).

### **Bestandspad‑workflow**

Het volgende voorbeeld valideert een openingswachtwoord voor een PPTX‑bestand, geeft de gevalideerde waarde door aan [ILoadOptions.setPassword](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-), en laadt vervolgens de volledige presentatie:

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

### **Stream‑workflow**

De stream‑overload van [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) biedt dezelfde workflow. Reset de positie van een doorzoekbare stream voordat u de volledige presentatie uit die stream laadt.

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

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) retourneert `true` alleen wanneer de presentatie een openingswachtwoord heeft en het opgegeven wachtwoord correct is. Het retourneert `false` in elk van de volgende gevallen:

- Het wachtwoord is onjuist.
- De presentatie heeft geen openingswachtwoord.
- Het opgegeven wachtwoord is `null` of leeg.

Het gedrag is hetzelfde voor PPT‑ en PPTX‑presentaties.

## **Controleren of een geladen presentatie versleuteld is**

Na het laden van een presentatie met het juiste wachtwoord, inspecteer [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iprotectionmanager/#isEncrypted--) om te bevestigen dat de bronpresentatie versleuteld was. Om bescherming met een openingswachtwoord te detecteren vóór het laden, gebruik `IPresentationInfo.isPasswordProtected` zoals hierboven getoond.

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
Log openingswachtwoorden niet en voeg ze niet op in diagnostische berichten. Vermijd onnodige herhaalde validatiepogingen, houd wachtwoorden alleen zo lang in het geheugen als nodig is, en hergebruik een succesvol validatieresultaat bij het direct laden van de presentatie.
{{% /alert %}}

## **Een presentatie online met een wachtwoord beveiligen**

1. Open de applicatie [Aspose.Slides Lock](https://products.aspose.app/slides/nl/lock).
2. Selecteer of upload de presentatie.
3. Voer een wachtwoord in voor weergavebescherming.
4. Voer eventueel een apart wachtwoord in voor bewerkingsbescherming.
5. Pas de bescherming toe en download het resulterende bestand.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/nl/androidjava/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/nl/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Wat is het verschil tussen een openingswachtwoord en een schrijfbeschermingswachtwoord?**

Een openingswachtwoord versleutelt de presentatie en is vereist om de inhoud te laden. Een schrijfbeschermingswachtwoord beperkt wijzigingen zonder de inhoud te versleutelen.

**Kan ik een openingswachtwoord valideren zonder alle dia's te laden?**

Ja. Verkrijg presentatiesinformatie, controleer of er een bescherming met een openingswachtwoord aanwezig is, en valideer het wachtwoord vóór het aanmaken van een volledige presentatietoestand.

**Ondersteunen de wachtwoord‑validatiewerkstromen zowel PPT als PPTX?**

Ja. Werkstromen op basis van bestandspad en stream voor wachtwoorddetectie en -validatie werken hetzelfde voor PPT‑ en PPTX‑presentaties.