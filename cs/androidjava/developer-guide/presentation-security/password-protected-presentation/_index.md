---
title: Ochrana prezentací heslem na Androidu
linktitle: Ochrana heslem
type: docs
weight: 20
url: /cs/androidjava/password-protected-presentation/
keywords:
- prezentace chráněná heslem
- otevírací heslo
- šifrovat PowerPoint
- dešifrovat PowerPoint
- ověřit heslo prezentace
- zkontrolovat heslo prezentace
- otevřít zašifrovanou prezentaci
- odstranit šifrování
- PowerPoint
- PPT
- PPTX
- prezentace
- Android
- Java
- Aspose.Slides
description: "Šifrujte, detekujte, ověřujte, otevírejte a dešifrujte prezentace PowerPoint PPT a PPTX chráněné heslem pomocí Aspose.Slides pro Android v Javě."
---
## **Přehled**

Otevírací heslo šifruje prezentaci. Správné heslo je vyžadováno pro načtení a zobrazení obsahu prezentace, takže tato ochrana poskytuje důvěrnost.

Otevírací heslo se liší od hesla pro ochranu proti zápisu. Ochrana proti zápisu omezuje úpravy, ale nešifruje obsah ani nebrání načtení prezentace. Pro správu hesel pro úpravu prezentací viz [Ochrana před zápisem prezentací](/slides/cs/androidjava/write-protected-presentation/).

Níže uvedené workflow platí pro prezentace PPT i PPTX. Příklady používají oba formáty, kde je důležité jejich chování při práci se soubory i se streamy.

## **Zašifrování prezentace otevíracím heslem**

Pro přiřazení otevíracího hesla použijte [IProtectionManager.encrypt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-). Poté použijte [IPresentation.save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) pro uložení zašifrované prezentace.

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

## **Načtení zašifrované prezentace**

Nastavte [ILoadOptions.setPassword](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) na otevírací heslo a předávejte možnosti třídě [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) při načítání souboru. Načítání selže, pokud je vyžadováno otevírací heslo, ale zadané heslo chybí nebo je nesprávné.

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

Načtěte prezentaci s jejím otevíracím heslem, zavolejte [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iprotectionmanager/#removeEncryption--), a uložte výsledek. Uloženou prezentaci lze následně načíst bez hesla.

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

Pro získání [IPresentationInfo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationinfo/) bez vytvoření úplné instance prezentace použijte [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-). Před žádostí o heslo nebo jeho ověřením zkontrolujte [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationinfo/#isPasswordProtected--). Pokud je ochrana přítomna, ověřte zadanou hodnotu pomocí [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-).

### **Workflow s cestou k souboru**

Následující příklad ověřuje otevírací heslo pro soubor PPTX, předává ověřenou hodnotu metodě [ILoadOptions.setPassword](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-), a poté načte celou prezentaci:

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

### **Workflow se streamem**

Přetížení streamu metody [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) poskytuje stejný workflow. Před načtením celé prezentace z tohoto streamu resetujte pozici vyhledávatelného streamu.

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

vrací `true` pouze tehdy, když má prezentace otevírací heslo a zadané heslo je správné. V každém z následujících případů vrací `false`:

- Heslo je nesprávné.
- Prezentace nemá otevírací heslo.
- Zadané heslo je `null` nebo prázdné.

Chování je stejné pro prezentace PPT i PPTX.

## **Kontrola, zda je načtená prezentace zašifrována**

Po načtení prezentace se správným heslem zkontrolujte [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iprotectionmanager/#isEncrypted--) a potvrďte, že zdrojová prezentace byla zašifrována. Pro detekci ochrany otevíracím heslem před načtením použijte `IPresentationInfo.isPasswordProtected`, jak je uvedeno výše.

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
Nezaznamenávejte otevírací hesla ani je nezahrnujte do diagnostických zpráv. Vyhněte se zbytečným opakovaným pokusům o ověření, uchovávejte hesla v paměti jen po nezbytně nutnou dobu a opakovaně použijte úspěšný výsledek ověření při okamžitém načtení prezentace.
{{% /alert %}}

## **Ochrana prezentace heslem online**

1. Otevřete aplikaci [Aspose.Slides Lock](https://products.aspose.app/slides/cs/lock).
2. Vyberte nebo nahrajte prezentaci.
3. Zadejte heslo pro ochranu při prohlížení.
4. Volitelně zadejte samostatné heslo pro ochranu úprav.
5. Aplikujte ochranu a stáhněte vzniklý soubor.

{{% alert color="info" title="Viz také" %}}
- [Ochrana před zápisem prezentací](/slides/cs/androidjava/write-protected-presentation/)
- [Digitální podpis v PowerPointu](/slides/cs/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Často kladené otázky**

**Jaký je rozdíl mezi otevíracím heslem a heslem pro ochranu proti zápisu?**

Otevírací heslo šifruje prezentaci a je vyžadováno pro načtení jejího obsahu. Heslo pro ochranu proti zápisu omezuje úpravy bez šifrování obsahu.

**Mohu ověřit otevírací heslo bez načtení všech snímků?**

Ano. Získejte informace o prezentaci, zjistěte, zda je přítomna ochrana otevíracím heslem, a ověřte heslo před vytvořením úplné instance prezentace.

**Podporují workflow pro ověření hesla jak PPT, tak PPTX?**

Ano. Workflow pro detekci a ověření hesla na základě cesty k souboru i streamu se chovají stejně u prezentací PPT i PPTX.