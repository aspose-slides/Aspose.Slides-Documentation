---
title: Licencelés
description: "Alkalmazzon egy licencfájlt az Aspose.Slides for Node.js via .NET-hez, tekintse meg az értékelő verzió korlátozásait, és szerezzen egy ingyenes 30 napos ideiglenes licencet a teszteléshez."
type: docs
weight: 80
url: /hu/nodejs-net/licensing/
---
## **Áttekintés**

Aspose.Slides for Node.js via .NET egy npm csomag, amelyet értékelésre és termelésre egyaránt használhat. Licenc nélkül értékelő módban fut. Miután megvásárol egy licencet, vagy ingyenes 30 napos ideiglenes licencet kap, néhány kódsor segítségével alkalmazza, és az értékelő korlátozások már nem érvényesek.

{{% alert color="info" title="Note" %}}

Az Aspose termékek értékelésével, licencelésével és megvásárlásával kapcsolatos általános irányelvek a [Vásárlási irányelvek és GYIK](https://purchase.aspose.com/policies) oldalon gyűjtve vannak. Az árak a [Ár információk](https://purchase.aspose.com/pricing/slides/family) oldalon vannak feltüntetve.

{{% /alert %}}

## **Értékelő verzió korlátozásai**

Az értékelő verzió a termék teljes funkcionalitását biztosítja, két korláttal:

- **Vízjel.** Minden mentett prezentáció minden diáján megjelenik egy értékelő vízjel: egy zárolt szövegdoboz a dia közepén, amely a „Evaluation only.” szöveget tartalmazza. Ugyanez a vízjel jelenik meg a PDF, XPS és HTML exportokban, valamint a dia képein.
- **Rövidített szöveg.** A kód által egy szövegkeretből, bekezdésből vagy részletből visszaolvasott szöveg az első öt karakterre van vágva, majd a következő üzenet következik: "... text has been truncated due to evaluation version limitation." A Markdown és HTML5 exportok is ugyanígy vannak rövidítve. A kód által írt szöveg teljesen mentésre kerül.

[Az Aspose.Slides értékelése](/slides/hu/nodejs-net/evaluate-aspose-slides/) részletesen leírja mindkét korlátozást és tartalmaz egy szkriptet, amely bemutatja őket.

{{% alert color="success" title="Tip" %}}

Az Aspose.Slides értékelő korlátozások nélküli teszteléséhez kérjen egy ingyenes **30 napos ideiglenes licencet**. A részletekért tekintse meg a [Hogyan lehet ideiglenes licencet szerezni?](https://purchase.aspose.com/temporary-license) oldalt.

{{% /alert %}}

## **A licencről**

A licenc egy egyszerű szöveges XML fájl, amely tartalmazza a termék nevét, a licencelt fejlesztők számát és a előfizetés lejárati dátumát. A fájl digitálisan alá van írva, ezért ne módosítsa: még egy véletlenül hozzáadott sortörés is érvényteleníti.

## **Licenc alkalmazása**

Alkalmazza a licencet a `License` osztály `setLicense` metódusával. Hívja meg egyszer a folyamatban, mielőtt bármely `Presentation` objektumot létrehozná. Az újbóli hívás nem árt, de megismétli a már elvégzett munkát.

Az alábbi szkript egy `Aspose.Slides.lic` nevű fájlból alkalmaz licencet. Cserélje le a nevet a licencfájl nevére vagy teljes elérési útjára; a fájlnak bármilyen neve lehet.

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { License } = asposeSlides;

const license = new License();
try {
    license.setLicense("Aspose.Slides.lic");
    console.log("License applied.");
} catch (error) {
    console.log("License not applied:", error.message);
}
```

A fájlnév vagy relatív útvonal a jelenlegi mappához viszonyítva kerül feloldásra, ami az a könyvtár, ahonnan a `node` parancsot futtatja. Tartsa a licencfájlt a projekt mappájában, és onnan futtassa a szkripteket, vagy adja meg a teljes elérési utat.

Ha a fájl nem található, vagy nem érvényes licenc, a `setLicense` hibát dob, és az Aspose.Slides értékelő módban marad. A szkript elkapja a hibát és kiírja az üzenetét. Hiányzó fájl esetén az üzenet a `License "Aspose.Slides.lic" doesn't exist or access is restricted.` szöveggel kezdődik, és felsorolja az összes keresett helyet.

Ebben a csomagban a licenc csak fájlból alkalmazható. A `License` nem fogad adatfolyamot, és a csomag nem biztosít mérés alapú licencet. A csomag által becsomagolt osztályról lásd a [License](https://reference.aspose.com/slides/net/aspose.slides/license/) oldalt az Aspose.Slides for .NET API referenciaiban.