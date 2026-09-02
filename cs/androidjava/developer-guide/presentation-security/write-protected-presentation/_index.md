---
title: Zápisová ochrana prezentací na Androidu
linktitle: Zápisová ochrana
type: docs
weight: 25
url: /cs/androidjava/write-protected-presentation/
keywords:
- zápisová ochrana
- zápisová ochrana PowerPoint
- heslo pro úpravy
- omezit úpravy prezentace
- odebrat zápisovou ochranu
- ověřit heslo pro úpravy
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Nastavte, detekujte, ověřujte a odstraňujte hesla zápisové ochrany v prezentacích PowerPoint PPT a PPTX pomocí Aspose.Slides pro Android v Javě."
---
## **Úvod**

Heslo pro zápisové ochrany omezuje úpravy prezentace, ale nešifruje její obsah. Uživatelé mohou načíst a zobrazit prezentaci chráněnou proti zápisu bez hesla. V závislosti na aplikaci mohou také upravovat obsah a uložit jej pod jiným názvem, takže zápisová ochrana by neměla být považována za prostředek důvěrnosti.

Otevírací heslo slouží k jinému účelu: šifruje prezentaci a je vyžadováno pro načtení jejího obsahu. Pro šifrování prezentace nebo ověření otevíracího hesla viz [Password-Protect Presentations](/slides/cs/androidjava/password-protected-presentation/).

Postupy v tomto článku platí pro prezentace ve formátech PPT i PPTX. Příklady používají soubory PPTX; při ukládání do PPT použijte příponu `.ppt` a odpovídající formát ukládání PPT.

## **Nastavení zápisové ochrany prezentace**

Pro přiřazení hesla pro úpravu prezentace použijte [IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-). Uložení prezentace zachová nastavení ochrany.

Následující příklad nastaví zápisovou ochranu na PPTX prezentaci:

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

Protože zápisová ochrana nešifruje obsah prezentace, není pro načtení prezentace vyžadováno žádné heslo. Heslo je relevantní pouze při ověřování oprávnění upravit chráněnou prezentaci.

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Nezadávejte heslo zápisové ochrany metodě [ILoadOptions.setPassword](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-). Tato metoda přijímá otevírací heslo pro šifrovaný obsah. Pokud má prezentace oba typy ochrany, zadejte otevírací heslo pro její načtení a heslo zápisové ochrany ošetřete samostatně.

## **Odebrání zápisové ochrany z prezentace**

Pro odebrání omezení úprav použijte [IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iprotectionmanager/#removeWriteProtection--) a poté prezentaci uložte.

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

Pro inspekci souboru bez vytvoření úplné instance [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) zavolejte [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) a proveďte kontrolu [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--). Metoda používá [NullableBool](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/nullablebool/) a vrací `NullableBool.True`, pokud je detekována zápisová ochrana.

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

Přetížení pro proud metoda [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) poskytuje stejnou informaci pro prezentaci dodanou jako proud.

## **Ověření hesla zápisové ochrany**

Pro ověření hesla pro úpravy bez načtení celé prezentace použijte [IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-). Nejprve zkontrolujte [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--), aby aplikace požadovala nebo ověřovala heslo pouze v případě, že je zápisová ochrana přítomna.

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

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) ověřuje pouze heslo zápisové ochrany. Neověřuje otevírací heslo ani neurčuje, zda lze načíst šifrovaný obsah. Naopak [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) ověřuje pouze otevírací heslo. Pokud již byla načtena úplná prezentace, poskytuje [IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-) ekvivalentní kontrolu zápisové ochrany prostřednictvím svého správce ochrany.

V produkčních aplikacích neukládejte hesla do protokolů ani je neuvádějte v diagnostických zprávách. Vyhněte se zbytečným opakovaným pokusům o ověření a uchovávejte hesla v paměti jen po nezbytně potřebnou dobu.

{{% alert color="info" title="Viz také" %}}
- [Prezentace chráněné heslem](/slides/cs/androidjava/password-protected-presentation/)
- [Prezentace pouze pro čtení](/slides/cs/androidjava/read-only-presentation/)
- [Digitální podpis v PowerPointu](/slides/cs/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Často kladené otázky**

**Zabezpečuje zápisová ochrana prezentaci šifrováním?**

Ne. Omezuje úpravy, ale obsah prezentace zůstává k dispozici pro načtení a zobrazení.

**Je heslo zápisové ochrany vyžadováno pro otevření prezentace?**

Ne. K načtení šifrovaného obsahu prezentace je vyžadováno pouze otevírací heslo.

**Může mít prezentace jak otevírací heslo, tak heslo zápisové ochrany?**

Ano. Otevírací heslo zadejte prostřednictvím možností načtení pro otevření šifrované prezentace a heslo zápisové ochrany ověřujte samostatně, když je vyžadováno oprávnění k úpravě.