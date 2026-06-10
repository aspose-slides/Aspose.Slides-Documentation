---
title: Gyakran Ismételt Kérdések
type: docs
weight: 110
url: /hu/reportingservices/frequently-asked-questions/
---
{{% alert color="primary" %}} 

Ez az oldal számos gyakran feltett kérdést gyűjt össze a következőkről:

- [Támogatott fájlformátumok](#Supported-File-Formats).
- [Power BI Reporting services támogatása](#Support-for-Power-BI-Reporting-services).
- [Telepítés](#Installation).
- [Export konfiguráció](#Export-Configuration).

{{% /alert %}} 
### **Támogatott fájlformátumok**
#### **Q: Milyen formátumokba tudja exportálni a jelentéseket az Aspose.Slides for Reporting Services használatával?**
**A**: Az Aspose.Slides for Reporting Services lehetővé teszi bármely jelentés exportálását PPT, PPS, PPTX, PPSX, XPS vagy RPL formátumba.
### **Power BI Reporting services támogatása**
#### **Q: Támogatja-e az Aspose.Slides for Reporting Services a Power BI-t?**
**A**: Igen. Az Aspose.Slides for Reporting Services támogatja a paginált jelentések (RDL) exportálását a Power BI-ban.
### **Telepítés**
#### **Q: A telepítő program nem indul el. A manuális telepítés nem vezet a kívánt eredményhez.**
**A** : Győződjön meg arról, hogy a .NET Framework 3.5 telepítve van a rendszerén.
#### **Q: Az exportálási lehetőségek hiányoznak az Aspose.Slides for Reporting Services telepítése után.**
**A**: Ha a rssrvpolicy.config bármely CodeGroup-ja nem működik megfelelően, a konfigurációs fájl elemzője kihagyhatja a csoport utolsó szekcióit. Ezért mozdítsa át az Aspose.Slides for Reporting Services-hez tartozó összes CodeGroup-ot a blokkon belül, amely az Aspose.Slides for Reporting Services CodeGroup-okat tartalmaz, a blokk tetejére.
#### **Q: Nem sikerült betölteni a Aspose.Slides.ReportingServices fájlt vagy assembly-t (A végrehajtási engedély nem szerezhető be \ Kivétel a HRESULT-től: 0x80131418).**
**A**: A hiba kód (0x80131418) azt jelzi, hogy a DLL modul nem rendelkezik elegendő jogosultsággal. Ez egy biztonsági funkciónak köszönhető, amely teljes hozzáférést blokkol a .dll fájlhoz, ha azt egy másik számítógépről szerezték be. A hiba javítható a DLL fájl tulajdonságok ablakának megnyitásával, majd a „Security” panelen a „Unblock” gomb megnyomásával.
#### **Q: Nem található a 'Aspose.Slides.Reporting.Services.lic' licensz.**
**A**: A licensz fájlnak a DLL mellett vagy a Program Files (x86)\Aspose\Slides\ könyvtárban kell lennie.
### **Export konfiguráció**
#### **Q: Hogyan változtathatom meg a hiperlinkek színét egy exportált jelentésben?**
**A**: Az rsreportserver.config fájlban minden Aspose.Slides for Reporting Services renderelési kiterjesztésnek saját konfigurációja van. A hiperlink színének megváltoztatásához állítsa be a kívánt értéket a <HyperlinkColor> szakaszban.
#### **Q: Az exportált prezentációkban a táblázatok szövege függőlegesen nyúlik.**
**A**: Ez a dokumentum olvashatóságának javítása érdekében történik. Ahhoz, hogy a táblázatban a szöveg a jelentésben megjelenő módon legyen látható, állítsa be a szükséges Aspose.Slides for Reporting Services kiterjesztést „Normal” értékre az rsreportserver.config konfigurációs fájlban.