---
title: Zabezpečení prezentací heslem v Javě
linktitle: Ochrana heslem
type: docs
weight: 20
url: /cs/java/password-protected-presentation/
keywords:
- prezentace chráněná heslem
- otevírací heslo
- šifrovat PowerPoint
- dešifrovat PowerPoint
- ověřit heslo prezentace
- zkontrolovat heslo prezentace
- otevřít šifrovanou prezentaci
- odstranit šifrování
- PowerPoint
- PPT
- PPTX
- prezentace
- Java
- Aspose.Slides
description: "Šifrujte, detekujte, ověřujte, otevírejte a dešifrujte prezentace PowerPoint PPT a PPTX chráněné heslem v Javě pomocí Aspose.Slides."
---
## **Přehled**

Otevírací heslo šifruje prezentaci. Pro načtení a zobrazení obsahu prezentace je vyžadováno správné heslo, takže tato ochrana zajišťuje důvěrnost.

Otevírací heslo se liší od hesla pro ochranu proti zápisu. Ochrana proti zápisu omezuje úpravy, ale nešifruje obsah ani nebrání načtení prezentace. Pro správu hesel pro úpravy prezentací viz [Write-Protect Presentations](/slides/cs/java/write-protected-presentation/).

Níže uvedené postupy platí pro prezentace PPT i PPTX. Příklady používají oba formáty, kde je důležité jejich chování při práci se soubory i s proudy.

## **Šifrování prezentace otevíracím heslem**

Pro přiřazení otevíracího hesla použijte [IProtectionManager.encrypt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-). Pak použijte [IPresentation.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) pro uložení šifrované prezentace.

Následující příklad šifruje PPTX prezentaci:

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

## **Načtení šifrované prezentace**

Nastavte [ILoadOptions.setPassword](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) na otevírací heslo a při načítání souboru předávejte možnosti do [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/). Načítání selže, pokud je vyžadováno otevírací heslo, ale zadané heslo chybí nebo je nesprávné.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Pracujte s dešifrovanou prezentací.
} finally {
    presentation.dispose();
}
```

## **Odstranění šifrování z prezentace**

Načtěte prezentaci s jejím otevíracím heslem, zavolejte [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iprotectionmanager/#removeEncryption--), a uložte výsledek. Uložená prezentace pak může být načtena bez hesla.

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

## **Ověření otevíracího hesla před načtením**

Pro získání [IPresentationInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationinfo/) bez vytvoření úplné instance prezentace použijte [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-). Před požádáním o heslo nebo jeho ověřením zkontrolujte [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--). Pokud je ochrana přítomna, ověřte zadanou hodnotu pomocí [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-).

### **Pracovní postup s cestou k souboru**

Následující příklad ověřuje otevírací heslo pro PPTX soubor, předá ověřenou hodnotu metodě [ILoadOptions.setPassword](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) a poté načte úplnou prezentaci:

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

### **Pracovní postup s proudem**

Přetížení metody pro proud v [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) poskytuje stejný postup. Resetujte pozici prohledávaného proudu před načtením celé prezentace z tohoto proudu.

Následující příklad používá PPT soubor:

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

### **Návratové hodnoty metody checkPassword**

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) vrací `true` pouze tehdy, když má prezentace otevírací heslo a zadané heslo je správné. Vrací `false` v každém z následujících případů:

- Heslo je nesprávné.
- Prezentace nemá otevírací heslo.
- Zadané heslo je `null` nebo prázdné.

Chování je stejné pro PPT i PPTX prezentace.

## **Zjištění, zda je načtená prezentace šifrovaná**

Po načtení prezentace se správným heslem zkontrolujte [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iprotectionmanager/#isEncrypted--) a potvrďte, že zdrojová prezentace byla šifrována. Pro detekci ochrany otevíracím heslem před načtením použijte `IPresentationInfo.isPasswordProtected`, jak je uvedeno výše.

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

## **Doporučení pro zabezpečení**

{{% alert color="warning" title="Zabezpečení" %}}
Nelogujte otevírací hesla ani je nezahrnujte do diagnostických zpráv. Vyhněte se zbytečným opakovaným pokusům o ověření, uchovávejte hesla v paměti pouze po dobu, kdy jsou potřebná, a opakovaně použijte úspěšný výsledek ověření při okamžitém načítání prezentace.
{{% /alert %}}

## **Ochrana prezentace heslem online**

1. Otevřete aplikaci [Aspose.Slides Lock](https://products.aspose.app/slides/cs/lock).
1. Vyberte nebo nahrajte prezentaci.
1. Zadejte heslo pro ochranu zobrazení.
1. Volitelně zadejte samostatné heslo pro ochranu úprav.
1. Použijte ochranu a stáhněte výsledný soubor.

{{% alert color="info" title="Viz také" %}}
- [Write-Protect Presentations](/slides/cs/java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/cs/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Často kladené otázky**

**Jaký je rozdíl mezi otevíracím heslem a heslem pro ochranu proti zápisu?**

Otevírací heslo šifruje prezentaci a je vyžadováno pro načtení jejího obsahu. Heslo pro ochranu proti zápisu omezuje úpravy bez šifrování obsahu.

**Mohu ověřit otevírací heslo, aniž bych načetl všechny snímky?**

Ano. Získejte informace o prezentaci, zjistěte, zda je přítomna ochrana otevíracím heslem, a ověřte heslo před vytvořením úplné instance prezentace.

**Podporují postupy ověřování hesla jak PPT, tak PPTX?**

Ano. Detekce a ověřování hesla na základě cesty k souboru i proudu se chovají stejně pro PPT i PPTX prezentace.