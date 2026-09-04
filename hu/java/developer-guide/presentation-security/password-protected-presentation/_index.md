---
title: Jelszóval védett bemutatók Java-ban
linktitle: Jelszóvédelem
type: docs
weight: 20
url: /hu/java/password-protected-presentation/
keywords:
- jelszóval védett bemutató
- megnyitási jelszó
- PowerPoint titkosítása
- PowerPoint visszafejtése
- bemutató jelszó ellenőrzése
- bemutató jelszó vizsgálata
- titkosított bemutató megnyitása
- titkosítás eltávolítása
- PowerPoint
- PPT
- PPTX
- bemutató
- Java
- Aspose.Slides
description: "Titkosítsa, detektálja, ellenőrizze, nyissa meg és fejtse vissza a jelszóval védett PowerPoint PPT és PPTX bemutatókat Java-ban az Aspose.Slides segítségével."
---
## **Áttekintés**

A megnyitási jelszó titkosítja a bemutatót. A helyes jelszó szükséges a bemutató tartalmának betöltéséhez és megtekintéséhez, ezért ez a védelem bizalmasságot biztosít.

A megnyitási jelszó különbözik az írásvédelmi jelszótól. Az írásvédelem korlátozza a módosítást, de nem titkosítja a tartalmat, és nem akadályozza meg a bemutató betöltését. A bemutatók módosításához használt jelszavak kezeléséhez lásd a [Írásvédett bemutatók](/slides/hu/java/write-protected-presentation/) oldalt.

Az alábbi munkafolyamatok PPT és PPTX bemutatókra egyaránt vonatkoznak. A példák mindkét formátumot használják, ahol a fájlalapú és az adatfolyam‑alapú viselkedés fontos.

## **Titkosítás bemutató megnyitási jelszóval**

Használja a [IProtectionManager.encrypt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) metódust a megnyitási jelszó hozzárendeléséhez. Ezután használja a [IPresentation.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) metódust a titkosított bemutató mentéséhez.

A következő példa titkosít egy PPTX bemutatót:

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

## **Dokumentumtulajdonságok nyilvános tartása**

Alapértelmezés szerint az Aspose.Slides a dokumentumtulajdonságokat is belefoglalja a bemutató titkosításába. A [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) metódus ezt a viselkedést a dia‑tartalom titkosításától függetlenül szabályozza. Hívja meg a `false` értéket az [IProtectionManager.encrypt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) meghívása előtt, amikor egy indexelési, osztályozási, keresési vagy dokumentumkezelő rendszernek a metafájlok jelszó nélkül kell olvasnia.

A következő példa titkosított PPTX bemutatót hoz létre, miközben a beépített dokumentumtulajdonságokat nyilvános állapotban hagyja:

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

`false` érték átadása a [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) metódusnak nem teszi a diákat, mesteroldalakat, elrendezéseket, alakzatokat, médiát vagy más bemutatótartalmat nyilvánossá. Csak a dokumentumtulajdonságokra hat. Ezeknek a tulajdonságoknak a jelszó nélküli olvasásához lásd a [Bemutató tulajdonságok kezelése](/slides/hu/java/presentation-properties/) oldalt.

## **Titkosított bemutató betöltése**

Állítsa a [ILoadOptions.setPassword](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) értékét a megnyitási jelszóra, és adja át a beállításokat a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztálynak a fájl betöltésekor. A betöltés meghiúsul, ha megnyitási jelszó szükséges, de a megadott jelszó hiányzik vagy helytelen.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Munkáljon a visszafejtett bemutatóval.
} finally {
    presentation.dispose();
}
```

## **Titkosítás eltávolítása a bemutatóból**

Töltse be a bemutatót a megnyitási jelszóval, hívja meg a [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iprotectionmanager/#removeEncryption--) metódust, majd mentse az eredményt. A mentett bemutató ezután jelszó nélkül betölthető.

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

## **Megnyitási jelszó érvényesítése betöltés előtt**

Használja a [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) metódust a [IPresentationInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationinfo/) beszerzéséhez anélkül, hogy teljes bemutató‑példányt hozna létre. Ellenőrizze a [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) értékét, mielőtt jelszót kérne vagy érvényesítene. Ha védelem van jelen, érvényesítse a megadott értéket a [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) metódussal.

### **Fájlútvonal munkafolyamat**

A következő példa validál egy megnyitási jelszót egy PPTX fájlhoz, átadja a validált értéket az [ILoadOptions.setPassword](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) metódusnak, majd betölti a teljes bemutatót:

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

### **Adatfolyam munkafolyamat**

Az [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) adatfolyam‑túlterhelése ugyanazt a munkafolyamatot biztosítja. Állítsa vissza a kereshető adatfolyam pozícióját, mielőtt a teljes bemutatót betöltené ebből az adatfolyamból.

A következő példa PPT fájlt használ:

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

### **checkPassword visszatérési értékek**

Az [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) `true`‑t ad vissza csak akkor, ha a bemutató megnyitási jelszóval védett és a megadott jelszó helyes. `false`‑t ad az alábbi esetekben:

- A jelszó helytelen.
- A bemutató nem rendelkezik megnyitási jelszóval.
- A megadott jelszó `null` vagy üres.

A viselkedés PPT és PPTX bemutatók esetén is ugyanaz.

## **Ellenőrizze, hogy a betöltött bemutató titkosított-e**

A helyes jelszóval történő betöltés után vizsgálja meg az [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iprotectionmanager/#isEncrypted--) állapotát, hogy megerősítse a forrás‑bemutató titkosítását. A megnyitási jelszóval való védelem felismeréséhez a betöltés előtt használja a `IPresentationInfo.isPasswordProtected` értéket, ahogy fentebb is bemutattuk.

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

## **Biztonsági ajánlások**

{{% alert color="warning" title="Biztonság" %}}
Ne naplózza a megnyitási jelszavakat, és ne helyezze őket diagnosztikai üzenetekbe. Kerülje a szükségtelen, ismételt érvényesítési kísérleteket, tartsa a jelszavakat a memóriában csak a szükséges ideig, és használja újra a sikeres érvényesítés eredményét, ha azonnal betölti a bemutatót.

A nyilvános dokumentumtulajdonságok felfedhetik a szerző nevét, címét, tárgyát, kulcsszavait, a vállalati információkat, megjegyzéseket és egyedi értékeket, még akkor is, ha a bemutató tartalma titkosított. Titkosítsa az érzékeny metaadatokat a bemutatóval együtt. A tulajdonságok nyilvánosra hagyása csak akkor legyen kifejezett döntés, ha a rendszereknek indexelni, osztályozni, keresni vagy kezelni kell a fájlt megnyitási jelszó nélkül.
{{% /alert %}}

## **Bemutató jelszóval való védelme online**

1. Nyissa meg az [Aspose.Slides Lock](https://products.aspose.app/slides/hu/lock) alkalmazást.
2. Válassza ki vagy töltse fel a bemutatót.
3. Adjon meg egy jelszót a megtekintés védelméhez.
4. Opcionálisan adjon meg külön jelszót a szerkesztés védelméhez.
5. Alkalmazza a védelmet, és töltse le a kapott fájlt.

{{% alert color="info" title="Lásd még" %}}
- [Írásvédett bemutatók](/slides/hu/java/write-protected-presentation/)
- [Digitális aláírás PowerPointban](/slides/hu/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **GYIK**

**Mi a különbség a megnyitási jelszó és az írásvédelmi jelszó között?**

A megnyitási jelszó titkosítja a bemutatót, és a tartalom betöltéséhez szükséges. Az írásvédelmi jelszó korlátozza a módosítást anélkül, hogy titkosítaná a tartalmat.

**Érvényesíthetem a megnyitási jelszót anélkül, hogy az összes diát betölteném?**

Igen. Szerezze be a bemutató információit, ellenőrizze, hogy van‑e megnyitási jelszós védelem, és validálja a jelszót a teljes bemutató‑példány létrehozatala előtt.

**Olvashat‑e egy alkalmazás metaadatokat a megnyitási jelszó nélkül?**

Igen, de csak akkor, ha a bemutató dokumentumtulajdonság‑titkosítása le van tiltva. Ebben az esetben az alkalmazásnak a [Bemutató tulajdonságok kezelése](/slides/hu/java/presentation-properties/) leírt módon kell a csak dokumentumtulajdonságokra korlátozott betöltési módot használni.

**Támogatják a jelszó‑ellenőrző munkafolyamatok a PPT és PPTX formátumokat is?**

Igen. A fájl‑útvonal és az adatfolyam‑alapú jelszó‑detekció és validálás ugyanúgy működik PPT és PPTX bemutatók esetén.