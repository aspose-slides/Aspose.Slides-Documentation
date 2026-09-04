---
title: Zamknutí prezentací heslem v Javě
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
description: "Šifrovat, detekovat, ověřovat, otevírat a dešifrovat prezentace PowerPoint PPT a PPTX chráněné heslem v Javě pomocí Aspose.Slides."
---
## **Přehled**

Otevírací heslo šifruje prezentaci. Správné heslo je vyžadováno pro načtení a zobrazení obsahu prezentace, takže tato ochrana poskytuje důvěrnost.

Otevírací heslo se liší od hesla pro ochranu proti zápisu. Ochrana proti zápisu omezuje úpravy, ale nešifruje obsah ani nebrání načtení prezentace. Pro správu hesel pro úpravy prezentací viz [Zamknout prezentace](/slides/cs/java/write-protected-presentation/).

Níže uvedené postupy platí jak pro PPT, tak pro PPTX prezentace. Příklady používají oba formáty, kde je důležité chování založené na souboru i na proudu.

## **Šifrování prezentace otevíracím heslem**

Použijte [IProtectionManager.encrypt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) k přiřazení otevíracího hesla. Poté použijte [IPresentation.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) k uložení šifrované prezentace.

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

## **Zveřejnit vlastnosti dokumentu**

Ve výchozím nastavení zahrnuje Aspose.Slides vlastnosti dokumentu do šifrování prezentace. Metoda [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) řídí toto chování nezávisle na šifrování obsahu snímků. Před voláním [IProtectionManager.encrypt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) předávejte `false`, pokud musí systém pro indexování, klasifikaci, vyhledávání nebo správu dokumentů číst metadata bez otevíracího hesla.

Následující příklad vytvoří šifrovanou PPTX prezentaci a zároveň ponechá její vestavěné vlastnosti dokumentu veřejné:

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

Předání `false` metodě [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) nezpřístupní snímky, hlavní motivy, rozvržení, tvary, média ani jiný obsah prezentace. Ovlivní pouze vlastnosti dokumentu. Pro čtení těchto vlastností bez načítání šifrovaného obsahu viz [Spravovat vlastnosti prezentace](/slides/cs/java/presentation-properties/).

## **Načtení šifrované prezentace**

Nastavte [ILoadOptions.setPassword](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) na otevírací heslo a předávejte volby při vytváření [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) při načítání souboru. Načítání selže, pokud je vyžadováno otevírací heslo a zadané heslo chybí nebo je nesprávné.

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

Načtěte prezentaci s jejím otevíracím heslem, zavolejte [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iprotectionmanager/#removeEncryption--) a výsledek uložte. Uložená prezentace může být následně načtena bez hesla.

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

Použijte [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) k získání [IPresentationInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationinfo/) bez vytváření kompletní instance prezentace. Zkontrolujte [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) před požádáním o heslo nebo jeho ověřením. Pokud je ochrana přítomna, ověřte zadanou hodnotu pomocí [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-).

### **Postup s cestou k souboru**

Následující příklad ověří otevírací heslo pro soubor PPTX, předá ověřenou hodnotu metodě [ILoadOptions.setPassword](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) a poté načte kompletní prezentaci:

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

### **Postup s proudem**

Přetížená metoda proudu [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) poskytuje stejný postup. Před načtením kompletní prezentace z proudu resetujte pozici seekable proudu.

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

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) vrací `true` pouze tehdy, když má prezentace otevírací heslo a zadané heslo je správné. Vrací `false` ve všech následujících případech:

- Heslo je nesprávné.
- Prezentace nemá otevírací heslo.
- Zadané heslo je `null` nebo prázdné.

Chování je stejné pro PPT i PPTX prezentace.

## **Zkontrolovat, zda načtená prezentace je šifrovaná**

Po načtení prezentace se správným heslem zkontrolujte [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iprotectionmanager/#isEncrypted--) pro potvrzení, že zdrojová prezentace byla šifrována. Pro detekci ochrany otevíracím heslem před načtením použijte `IPresentationInfo.isPasswordProtected`, jak je ukázáno výše.

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
Nezaznamenávejte otevírací hesla ani je nezahrnujte do diagnostických zpráv. Vyhněte se zbytečným opakovaným pokusům o ověření, uchovávejte hesla v paměti jen po dobu nezbytně nutnou a použijte úspěšný výsledek ověření při okamžitém načtení prezentace.

Veřejné vlastnosti dokumentu mohou odhalit jména autorů, názvy, předměty, klíčová slova, informace o společnosti, komentáře a vlastní hodnoty, i když je obsah prezentace šifrován. Šifrujte citlivá metadata spolu s prezentací. Zveřejnění vlastností by mělo být explicitním rozhodnutím učiněným pouze tehdy, když systémy musí indexovat, klasifikovat, vyhledávat nebo spravovat soubor bez otevíracího hesla.
{{% /alert %}}

## **Zamknout prezentaci heslem online**

1. Otevřete aplikaci [Aspose.Slides Lock](https://products.aspose.app/slides/cs/lock).
1. Vyberte nebo nahrajte prezentaci.
1. Zadejte heslo pro ochranu zobrazení.
1. Volitelně zadejte samostatné heslo pro ochranu úprav.
1. Aplikujte ochranu a stáhněte výsledný soubor.

{{% alert color="info" title="Viz také" %}}
- [Zamknout prezentace](/slides/cs/java/write-protected-presentation/)
- [Digitální podpis v PowerPointu](/slides/cs/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Často kladené otázky**

**Jaký je rozdíl mezi otevíracím heslem a heslem pro ochranu proti zápisu?**

Otevírací heslo šifruje prezentaci a je vyžadováno pro načtení jejího obsahu. Heslo pro ochranu proti zápisu omezuje úpravy bez šifrování obsahu.

**Mohu ověřit otevírací heslo bez načtení všech snímků?**

Ano. Získejte informace o prezentaci, zjistěte, zda je přítomna ochrana otevíracím heslem, a ověřte heslo před vytvořením kompletní instance prezentace.

**Může aplikace číst metadata bez otevíracího hesla?**

Ano, ale pouze pokud byla prezentace šifrována s vypnutým šifrováním vlastností dokumentu. Aplikace pak musí použít režim načítání pouze vlastností dokumentu popsaný v [Spravovat vlastnosti prezentace](/slides/cs/java/presentation-properties/).

**Podporují postupy pro kontrolu hesla jak PPT, tak PPTX?**

Ano. Detekce a ověření hesla na základě cesty k souboru i proudu se chovají stejně u PPT i PPTX prezentací.