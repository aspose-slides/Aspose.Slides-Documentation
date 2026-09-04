---
title: Bemutatók jelszóval védése Androidon
linktitle: Jelszóvédelem
type: docs
weight: 20
url: /hu/androidjava/password-protected-presentation/
keywords:
- jelszóval védett bemutató
- nyitó jelszó
- PowerPoint titkosítása
- PowerPoint visszafejtése
- bemutató jelszavának ellenőrzése
- bemutató jelszó ellenőrzése
- titkosított bemutató megnyitása
- titkosítás eltávolítása
- PowerPoint
- PPT
- PPTX
- bemutató
- Android
- Java
- Aspose.Slides
description: "Titkosíts, észlelj, ellenőriz, nyiss meg és visszafejts jelszóval védett PowerPoint PPT és PPTX bemutatókat az Aspose.Slides for Android segítségével Java nyelven."
---
## **Áttekintés**

A nyitó jelszó titkosítja a bemutatót. A helyes jelszó szükséges a bemutató tartalmának betöltéséhez és megtekintéséhez, ezért ez a védelem titkosságot biztosít.

A nyitó jelszó különbözik az írásvédelmi jelszótól. Az írásvédelem korlátozza a módosítást, de nem titkosítja a tartalmat, és nem akadályozza meg a bemutató betöltését. A bemutatók módosításához használt jelszavak kezeléséről lásd a [Írásvédelem a bemutatókhoz](/slides/hu/androidjava/write-protected-presentation/).

Az alábbi munkafolyamatok PPT és PPTX bemutatókra egyaránt vonatkoznak. A példák mindkét formátumot használják, ahol a fájl‑alapú és az adatfolyam‑alapú viselkedés fontos.

## **Titkosítás nyitó jelszóval**

Használd az [IProtectionManager.encrypt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) metódust nyitó jelszó hozzárendeléséhez. Ezután használd az [IPresentation.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) metódust a titkosított bemutató mentéséhez.

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

## **A dokumentumtulajdonságok nyilvánosak maradnak**

Alapértelmezés szerint az Aspose.Slides a dokumentumtulajdonságokat is belefoglalja a bemutató titkosításába. Az [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) metódus ezt a viselkedést a diatartalom titkosításától függetlenül szabályozza. Add meg a `false` értéket az [IProtectionManager.encrypt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) meghívása előtt, ha egy indexelő, osztályozó, kereső vagy dokumentumkezelő rendszernek a nyitó jelszó nélkül kell olvasnia a metaadatokat.

A következő példa titkosított PPTX bemutatót hoz létre, miközben a beépített dokumentumtulajdonságokat nyilvánosan hagyja:

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

A `false` érték átadása az [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) metódusnak nem teszi nyilvánossá a diákat, fővázlatokat, elrendezéseket, alakzatokat, médiát vagy a bemutató egyéb tartalmát. Csak a dokumentumtulajdonságokra van hatása. A titkosított tartalom betöltése nélkül ezeknek a tulajdonságoknak az olvasásához lásd a [Manage Presentation Properties](/slides/hu/androidjava/presentation-properties/).

## **Titkosított bemutató betöltése**

Állítsd be az [ILoadOptions.setPassword](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) értékét a nyitó jelszóra, és add át a lehetőségeket a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztálynak a fájl betöltésekor. A betöltés sikertelen, ha nyitó jelszó szükséges, de a megadott jelszó hiányzik vagy helytelen.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Dolgozz a visszafejtett bemutatóval.
} finally {
    presentation.dispose();
}
```

## **Titkosítás eltávolítása egy bemutatóból**

Töltsd be a bemutatót a nyitó jelszóval, hívd meg az [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iprotectionmanager/#removeEncryption--) metódust, és mentse az eredményt. A mentett bemutató ezután jelszó nélkül betölthető.

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

## **Nyitó jelszó ellenőrzése betöltés előtt**

Használd az [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) metódust az [IPresentationInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationinfo/) lekéréséhez anélkül, hogy teljes bemutató példányt hoznál létre. Ellenőrizd a [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) állapotát, mielőtt jelszót kérnél vagy érvényesítenél. Ha védelem van, ellenőrizd a megadott értéket az [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) segítségével.

### **Fájlútvonal munkafolyamat**

A következő példa ellenőrzi a nyitó jelszót egy PPTX fájlhoz, átadja a validált értéket az [ILoadOptions.setPassword](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) metódusnak, majd betölti a teljes bemutatót:

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

Az [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) adatfolyam túlterhelése ugyanazt a munkafolyamatot biztosítja. Állítsd vissza a kereshető adatfolyam pozícióját, mielőtt a teljes bemutatót betöltenéd ebből az adatfolyamból.

A következő példa egy PPT fájlt használ:

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

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) csak akkor ad vissza `true` értéket, ha a bemutató nyitó jelszóval védett és a megadott jelszó helyes. `false` értéket ad vissza az alábbi esetekben:
- A jelszó helytelen.
- A bemutatónak nincs nyitó jelszója.
- A megadott jelszó `null` vagy üres.

A viselkedés PPT és PPTX bemutatók esetén ugyanaz.

## **Ellenőrizd, hogy a betöltött bemutató titkosított‑e**

A bemutató helyes jelszóval történő betöltése után vizsgáld meg az [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iprotectionmanager/#isEncrypted--) metódust, hogy megerősítsd, a forrás bemutató titkosított volt. A nyitó jelszó védelem betöltés előtti észleléséhez használd a `IPresentationInfo.isPasswordProtected` értéket, ahogyan fent látható.

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

{{% alert color="warning" title="Security" %}}
Ne naplózd a nyitó jelszavakat, és ne tüntesd fel őket diagnosztikai üzenetekben. Kerüld a felesleges, ismételt ellenőrzési kísérleteket, tartsd a jelszavakat a memóriában csak annyira, amennyire szükség van, és használd újra a sikeres ellenőrzés eredményét, ha azonnal betöltöd a bemutatót.

A nyilvános dokumentumtulajdonságok felfedhetik a szerző nevét, címeket, tárgyakat, kulcsszavakat, céginformációkat, megjegyzéseket és egyedi értékeket, még akkor is, ha a bemutató tartalma titkosított. Titkosítsd a bizalmas metaadatokat együtt a bemutatóval. A tulajdonságok nyilvánossá tétele csak kifejezett döntés legyen, amikor a rendszereknek a fájlt nyitó jelszó nélkül kell indexelni, osztályozni, keresni vagy kezelni.
{{% /alert %}}

## **Jelszóval védeni a bemutatót online**

1. Nyisd meg az [Aspose.Slides Lock](https://products.aspose.app/slides/hu/lock) alkalmazást.
1. Válaszd ki vagy töltsd fel a bemutatót.
1. Adj meg egy jelszót a megjelenítés védelméhez.
1. Opcionálisan adj meg egy külön jelszót a szerkesztés védelméhez.
1. Alkalmazd a védelmet, és töltsd le a létrehozott fájlt.

{{% alert color="info" title="See also" %}}
- [Írásvédelem a bemutatókhoz](/slides/hu/androidjava/write-protected-presentation/)
- [Digitális aláírás a PowerPointban](/slides/hu/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **GYIK**

**Mi a különbség a nyitó jelszó és az írásvédelmi jelszó között?**

A nyitó jelszó titkosítja a bemutatót, és a tartalom betöltéséhez szükséges. Az írásvédelmi jelszó a módosítást korlátozza anélkül, hogy titkosítaná a tartalmat.

**Validálhatok nyitó jelszót anélkül, hogy betölteném az összes diát?**

Igen. Szerezd meg a bemutató információit, ellenőrizd, hogy nyitó jelszó védelem van‑e, és validáld a jelszót mielőtt teljes bemutató példányt hoznál létre.

**Olvashat egy alkalmazás metaadatokat nyitó jelszó nélkül?**

Igen, de csak akkor, ha a bemutató a dokumentumtulajdonságok titkosítása letiltott állapotban lett titkosítva. Ilyenkor az alkalmazásnak a [Manage Presentation Properties](/slides/hu/androidjava/presentation-properties/) leírásában szereplő csak‑dokumentumtulajdonságok betöltése módot kell használnia.

**Támogatja a jelszó‑ellenőrző munkafolyamat a PPT és PPTX formátumokat is?**

Igen. A fájlúton és adatfolyamon alapuló jelszó‑észlelés és ellenőrzés ugyanúgy működik PPT és PPTX bemutatók esetén.