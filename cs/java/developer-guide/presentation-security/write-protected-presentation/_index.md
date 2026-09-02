---
title: Zabezpečení prezentací proti zápisu v Javě
linktitle: Ochrana proti zápisu
type: docs
weight: 25
url: /cs/java/write-protected-presentation/
keywords:
- ochrana proti zápisu
- ochrana proti zápisu PowerPointu
- heslo pro úpravy
- omezit úpravy prezentace
- odebrat ochranu proti zápisu
- ověřit heslo pro úpravy
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Nastavte, detekujte, ověřujte a odstraňujte hesla ochrany proti zápisu v PowerPoint PPT a PPTX prezentacích pomocí Aspose.Slides pro Javu."
---
## **Úvod**

Heslo pro ochranu proti zápisu omezuje úpravy prezentace, ale nešifruje její obsah. Uživatelé mohou načíst a zobrazit prezentaci chráněnou proti zápisu bez hesla. V závislosti na aplikaci mohou být také schopni upravovat obsah a uložit jej pod jiným názvem, takže ochrana proti zápisu by neměla být považována za mechanismus důvěrnosti.

Otevírací heslo slouží k jinému účelu: šifruje prezentaci a je vyžadováno pro načtení jejího obsahu. Pro šifrování prezentace nebo ověření otevíracího hesla viz [Password-Protect Presentations](/slides/cs/java/password-protected-presentation/).

Postupy v tomto článku platí jak pro PPT, tak pro PPTX prezentace. Příklady používají soubory PPTX; při ukládání do PPT použijte příponu `.ppt` a odpovídající formát ukládání PPT.

## **Nastavení ochrany proti zápisu u prezentace**

Použijte [IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-) k přiřazení hesla pro úpravu prezentace. Uložení prezentace zachová nastavení ochrany.

Následující příklad nastaví ochranu proti zápisu u PPTX prezentace:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Načtení prezentace chráněné proti zápisu**

Protože ochrana proti zápisu nešifruje obsah prezentace, není pro načtení prezentace vyžadováno žádné heslo. Heslo je relevantní pouze při ověřování oprávnění k úpravě chráněné prezentace.

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Nevyplňujte heslo ochrany proti zápisu metodě [ILoadOptions.setPassword](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-). Tato metoda přijímá otevírací heslo pro šifrovaný obsah. Pokud má prezentace oba typy ochrany, poskytněte otevírací heslo pro její načtení a heslo ochrany proti zápisu zpracujte samostatně.

## **Odebrání ochrany proti zápisu z prezentace**

Použijte [IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iprotectionmanager/#removeWriteProtection--) k odebrání omezení úprav a poté prezentaci uložte.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kontrola, zda je prezentace chráněna proti zápisu**

Aby bylo možné prozkoumat soubor bez vytvoření úplné instance [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/), zavolejte [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) a zkontrolujte [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationinfo/#isWriteProtected--). Metoda používá [NullableBool](https://reference.aspose.com/slides/cs/java/com.aspose.slides/nullablebool/) a vrací `NullableBool.True`, pokud je detekována ochrana proti zápisu.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() == NullableBool.True) {
    System.out.println("The presentation is write protected.");
} else {
    System.out.println("Write protection was not detected.");
}
```

Přetížení pro stream metody [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) poskytuje stejnou informaci pro prezentaci předanou jako stream.

## **Ověření hesla ochrany proti zápisu**

Použijte [IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) k ověření hesla pro úpravy bez načtení celé prezentace. Nejprve zkontrolujte [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationinfo/#isWriteProtected--), aby aplikace požadovala nebo ověřovala heslo jen když je ochrana proti zápisu přítomna.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() != NullableBool.True) {
    System.out.println("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    System.out.println("The write-protection password is correct.");
} else {
    System.out.println("The write-protection password is incorrect.");
}
```

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) ověřuje pouze heslo ochrany proti zápisu. Neověřuje otevírací heslo ani nestanoví, zda lze načíst šifrovaný obsah. Naopak [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) ověřuje jen otevírací heslo. Pokud byla již načtena úplná prezentace, [IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-) poskytuje ekvivalentní kontrolu ochrany proti zápisu prostřednictvím svého správce ochrany.

V produkčních aplikacích neukládejte hesla do protokolů ani je nezahrnujte do diagnostických zpráv. Vyhněte se zbytečným opakovaným pokusům o ověření a uchovávejte hesla v paměti pouze po nezbytně nutnou dobu.

{{% alert color="info" title="See also" %}}
- [Ochrana prezentací heslem](/slides/cs/java/password-protected-presentation/)
- [Prezentace jen pro čtení](/slides/cs/java/read-only-presentation/)
- [Digitální podpis v PowerPointu](/slides/cs/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Často kladené otázky**

**Šifruje ochrana proti zápisu prezentaci?**

Ne. Omezuje úpravy, ale ponechává obsah prezentace dostupný pro načtení a prohlížení.

**Je heslo ochrany proti zápisu vyžadováno pro otevření prezentace?**

Ne. Pro načtení šifrovaného obsahu prezentace je vyžadováno pouze otevírací heslo.

**Může mít prezentace jak otevírací heslo, tak heslo ochrany proti zápisu?**

Ano. Otevírací heslo zadejte pomocí možností načtení pro otevření šifrované prezentace a heslo ochrany proti zápisu ověřujte samostatně, když je potřeba oprávnění k úpravám.