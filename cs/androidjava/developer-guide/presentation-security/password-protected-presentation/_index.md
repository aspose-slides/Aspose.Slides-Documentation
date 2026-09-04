---
title: Ochrana prezentací heslem na Androidu
linktitle: Ochrana heslem
type: docs
weight: 20
url: /cs/androidjava/password-protected-presentation/
keywords:
- prezentace chráněná heslem
- otevírací heslo
- šifrování PowerPointu
- dešifrování PowerPointu
- ověření hesla prezentace
- kontrola hesla prezentace
- otevření šifrované prezentace
- odstranění šifrování
- PowerPoint
- PPT
- PPTX
- prezentace
- Android
- Java
- Aspose.Slides
description: "Šifrujte, detekujte, ověřujte, otevírejte a dešifrujte prezentace PowerPoint PPT a PPTX chráněné heslem pomocí Aspose.Slides pro Android v jazyce Java."
---
## **Přehled**

Otevírací heslo šifruje prezentaci. Správné heslo je vyžadováno pro načtení a zobrazení obsahu prezentace, takže tato ochrana poskytuje důvěrnost.

Otevírací heslo se liší od hesla pro ochranu proti zápisu. Ochrana proti zápisu omezuje úpravy, ale nešifruje obsah ani nebrání načtení prezentace. Pro správu hesel pro úpravu prezentací viz [Write-Protect Presentations](/slides/cs/androidjava/write-protected-presentation/).

Níže uvedené postupy platí pro prezentace PPT i PPTX. Příklady používají oba formáty, kde je důležité chování při práci se souborem i se streamem.

## **Zašifrovat prezentaci pomocí otevíracího hesla**

Použijte [IProtectionManager.encrypt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) k přiřazení otevíracího hesla. Poté použijte [IPresentation.save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) k uložení zašifrované prezentace.

Následující příklad zašifruje PPTX prezentaci:

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

## **Udržet vlastnosti dokumentu veřejné**

Ve výchozím nastavení Aspose.Slides zahrnuje vlastnosti dokumentu do šifrování prezentace. Metoda [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) řídí toto chování nezávisle na šifrování obsahu snímků. Před voláním [IProtectionManager.encrypt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) předávejte `false`, pokud systém pro indexaci, klasifikaci, vyhledávání nebo správu dokumentů musí číst metadata bez otevíracího hesla.

Následující příklad vytvoří zašifrovanou PPTX prezentaci a zachová její vestavěné vlastnosti dokumentu veřejné:

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

Předání `false` metodě [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) nezpřístupní snímky, master‑stránky, rozvržení, tvary, média ani jiný obsah prezentace. Ovlivňuje jen vlastnosti dokumentu. Pro čtení těchto vlastností bez načítání zašifrovaného obsahu viz [Manage Presentation Properties](/slides/cs/androidjava/presentation-properties/).

## **Načíst zašifrovanou prezentaci**

Nastavte [ILoadOptions.setPassword](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) na otevírací heslo a předávejte možnosti při vytváření instance [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) během načítání souboru. Načtení selže, pokud je požadováno otevírací heslo a zadané heslo chybí nebo je nesprávné.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Práce s dešifrovanou prezentací.
} finally {
    presentation.dispose();
}
```

## **Odstranit šifrování z prezentace**

Načtěte prezentaci s jejím otevíracím heslem, zavolejte [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iprotectionmanager/#removeEncryption--) a výsledek uložte. Uložená prezentace může být následně načtena bez hesla.

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

## **Ověřit otevírací heslo před načtením**

Použijte [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) k získání [IPresentationInfo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationinfo/) bez vytváření kompletní instance prezentace. Před žádostí o heslo nebo jeho ověřením zkontrolujte [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationinfo/#isPasswordProtected--). Pokud je ochrana přítomna, ověřte zadanou hodnotu pomocí [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-).

### **Postup s cestou k souboru**

Následující příklad ověří otevírací heslo pro soubor PPTX, předá ověřenou hodnotu metodě [ILoadOptions.setPassword](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) a poté načte kompletní prezentaci:

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

### **Postup se streamem**

Přetížení streamu metody [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) poskytuje stejný postup. Před načtením kompletní prezentace ze streamu obnovte pozici vyhledatelného streamu.

Následující příklad používá soubor PPT:

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

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) vrací `true` pouze v případě, že prezentace má otevírací heslo a zadané heslo je správné. Vrací `false` v každém z těchto případů:

- Heslo je nesprávné.
- Prezentace nemá otevírací heslo.
- Zadané heslo je `null` nebo prázdné.

Chování je stejné pro prezentace PPT i PPTX.

## **Zkontrolovat, zda je načtená prezentace šifrovaná**

Po načtení prezentace se správným heslem zkontrolujte [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iprotectionmanager/#isEncrypted--) a potvrďte, že zdrojová prezentace byla šifrována. Pro detekci ochrany otevíracího hesla před načtením použijte `IPresentationInfo.isPasswordProtected`, jak bylo uvedeno výše.

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

{{% alert color="warning" title="Security" %}}
Nezapisujte otevírací hesla do logů ani je neuvádějte v diagnostických zprávách. Vyhněte se zbytečným opakovaným pokusům o ověření, uchovávejte hesla v paměti jen po nezbytně nutnou dobu a při okamžitém načtení prezentace použijte výsledek úspěšného ověření znovu.

Veřejné vlastnosti dokumentu mohou odhalit jména autorů, názvy, předměty, klíčová slova, informace o firmě, komentáře a vlastní hodnoty, i když je obsah prezentace šifrován. Šifrujte citlivá metadata spolu s prezentací. Nechávat vlastnosti veřejné by mělo být úmyslné rozhodnutí učiněné jen tehdy, když systémy musí indexovat, klasifikovat, vyhledávat nebo spravovat soubor bez otevíracího hesla.
{{% /alert %}}

## **Ochrana prezentace heslem online**

1. Otevřete aplikaci [Aspose.Slides Lock](https://products.aspose.app/slides/cs/lock).
1. Vyberte nebo nahrajte prezentaci.
1. Zadejte heslo pro ochranu zobrazení.
1. Volitelně zadejte samostatné heslo pro ochranu úprav.
1. Použijte ochranu a stáhněte výsledný soubor.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/cs/androidjava/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/cs/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Často kladené otázky**

**Jaký je rozdíl mezi otevíracím heslem a heslem pro ochranu proti zápisu?**

Otevírací heslo šifruje prezentaci a je vyžadováno k načtení jejího obsahu. Heslo pro ochranu proti zápisu omezuje úpravy bez šifrování obsahu.

**Mohu ověřit otevírací heslo bez načtení všech snímků?**

Ano. Získejte informace o prezentaci, zjistěte, zda je přítomna ochrana otevíracím heslem, a ověřte heslo před vytvořením kompletní instance prezentace.

**Může aplikace číst metadata bez otevíracího hesla?**

Ano, ale jen pokud byla prezentace šifrována s vypnutým šifrováním vlastností dokumentu. Aplikace pak musí použít režim načítání pouze vlastností dokumentu, který je popsán v [Manage Presentation Properties](/slides/cs/androidjava/presentation-properties/).

**Podporují pracovní postupy pro kontrolu hesla jak PPT, tak PPTX?**

Ano. Detekce a ověření hesla na základě cesty k souboru i streamu fungují stejně pro prezentace PPT i PPTX.