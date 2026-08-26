---
title: Írásvédett bemutatók C++-ban
linktitle: Írásvédelem
type: docs
weight: 25
url: /hu/cpp/write-protected-presentation/
keywords:
- írásvédelem
- PowerPoint írásvédelme
- módosítási jelszó
- a bemutató szerkesztésének korlátozása
- írásvédelem eltávolítása
- módosítási jelszó ellenőrzése
- PowerPoint
- bemutató
- C++
- Aspose.Slides
description: "Állítsa be, észlelje, ellenőrizze és távolítsa el az írásvédelmi jelszavakat PowerPoint PPT és PPTX bemutatókban az Aspose.Slides for C++ használatával."
---
## **Bevezetés**

Egy írásvédelem jelszó korlátozza a bemutató módosítását, de nem titkosítja a tartalmát. A felhasználók jelszó nélkül is betölthetik és megtekinthetik az írásvédett bemutatót. Az alkalmazástól függően szerkeszthetik a tartalmat és más néven menthetik, így az írásvédelmet nem szabad titoktartási mechanizmusként kezelni.

A megnyitási jelszó más cél szolgál: titkosítja a bemutatót, és a tartalom betöltéséhez szükséges. Egy bemutató titkosításához vagy a megnyitási jelszó érvényesítéséhez lásd a [Password-Protect Presentations](/slides/hu/cpp/password-protected-presentation/) cikket.

Az ebben a cikkben leírt munkafolyamatok mind a PPT, mind a PPTX bemutatókra vonatkoznak. A példák PPTX fájlokat használnak; PPT mentéskor a `.ppt` kiterjesztést és a megfelelő PPT mentési formátumot kell használni.

## **Írásvédelem beállítása egy bemutatón**

Használja az [IProtectionManager::SetWriteProtection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iprotectionmanager/setwriteprotection/) metódust a módosítási jelszó hozzárendeléséhez. A bemutató mentése elmenti a védelmi beállítást.

Az alábbi példa írásvédelmet állít be egy PPTX bemutatón:

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"modify_password");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Írásvédett bemutató betöltése**

Mivel az írásvédelem nem titkosítja a bemutató tartalmát, a betöltéshez nem szükséges jelszó. A jelszó csak akkor releváns, amikor a védett bemutató módosítási engedélyét ellenőrzik.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"write-protected-pres.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());
```

Ne adjon meg írásvédelmi jelszót a [LoadOptions::set_Password](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/set_password/) metódusnak. Ez a tulajdonság titkosított tartalomhoz szükséges megnyitási jelszót vár. Ha egy bemutatónak mindkét típusú védelem van, adja meg a megnyitási jelszót a betöltéshez, és kezelje külön az írásvédelmi jelszót.

## **Írásvédelem eltávolítása egy bemutatóból**

Használja az [IProtectionManager::RemoveWriteProtection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iprotectionmanager/removewriteprotection/) metódust a módosítási korlátozás megszüntetéséhez, majd mentse a bemutatót.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"write-protected-pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Annak ellenőrzése, hogy egy bemutató írásvédett-e**

Egy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) példány létrehozása nélkül egy fájl vizsgálatához hívja meg az [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) metódust, és ellenőrizze az [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/) tulajdonságot. A tulajdonság a [NullableBool](https://reference.aspose.com/slides/hu/cpp/aspose.slides/nullablebool/) típust használja, és `NullableBool::True` értéket ad, ha írásvédelem észlelhető.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/NullableBool.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"write-protected-pres.pptx");

if (presentationInfo->get_IsWriteProtected() == NullableBool::True)
{
    Console::WriteLine(u"The presentation is write protected.");
}
else
{
    Console::WriteLine(u"Write protection was not detected.");
}
```

Az [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) adatfolyam túlterhelése ugyanazt az információt nyújtja egy adatfolyamként megadott bemutatóhoz.

## **Írásvédelmi jelszó érvényesítése**

Használja az [IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) metódust a módosítási jelszó ellenőrzéséhez a teljes bemutató betöltése nélkül. Először ellenőrizze az [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/) értéket, hogy az alkalmazás csak akkor kérjen vagy ellenőrizzen jelszót, ha írásvédelem van jelen.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/NullableBool.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"write-protected-pres.pptx");

if (presentationInfo->get_IsWriteProtected() != NullableBool::True)
{
    Console::WriteLine(u"The presentation is not write protected.");
}
else if (presentationInfo->CheckWriteProtection(u"modify_password"))
{
    Console::WriteLine(u"The write-protection password is correct.");
}
else
{
    Console::WriteLine(u"The write-protection password is incorrect.");
}
```

Az [IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) csak az írásvédelmi jelszót ellenőrzi. Nem ellenőrzi a megnyitási jelszót, és nem állapítja meg, hogy titkosított tartalom betölthető-e. Ezzel szemben az [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationinfo/checkpassword/) csak egy megnyitási jelszót ellenőriz. Ha egy teljes bemutató már be van töltve, az [IProtectionManager::CheckWriteProtection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iprotectionmanager/checkwriteprotection/) a védelmi menedzserén keresztül biztosítja az ekvivalens írásvédelmi ellenőrzést.

Éles alkalmazásokban ne naplózzon jelszavakat, és ne helyezze őket diagnosztikai üzenetekbe. Kerülje a felesleges ismételt ellenőrzési kísérleteket, és a jelszavakat csak a szükséges ideig tartsa memóriában.

{{% alert color="info" title="Lásd még" %}}
- [Password-Protect Presentations](/slides/hu/cpp/password-protected-presentation/)
- [Read-Only Presentations](/slides/hu/cpp/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/hu/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **GYIK**

**Titkosítja-e az írásvédelem a bemutatót?**

Nem. A módosítást korlátozza, de a bemutató tartalma továbbra is betölthető és megtekinthető.

**A bemutató megnyitásához szükséges-e az írásvédelmi jelszó?**

Nem. Csak a megnyitási jelszó szükséges a titkosított bemutató tartalmának betöltéséhez.

**Lehet-e egy bemutatónak egyszerre megnyitási és írásvédelmi jelszava?**

Igen. A megnyitási jelszót a betöltési beállításokkal adja meg a titkosított bemutató megnyitásához, és a módosítási engedélyhez külön ellenőrizze az írásvédelmi jelszót.