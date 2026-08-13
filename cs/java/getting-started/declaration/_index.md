---
title: Deklarace
type: docs
weight: 60
url: /cs/java/declaration/
keywords:
- deklarace
- komponenty
- oprávnění Full Trust
- nastavení registru
- systémové soubory
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Zjistěte informace o požadavcích na důvěru, oprávněních a omezeních hostování Aspose.Slides pro Java, abyste mohli bezpečně nasadit aplikace zpracovávající PPT, PPTX a ODP na serverech."
---
{{% alert color="info" %}} 

Všechny komponenty Aspose Java vyžadují nastavení oprávnění Full Trust. Důvodem je, že komponenty Aspose Java potřebují přístup k nastavením registru, systémovým souborům mimo virtuální adresář pro určité operace, jako je parsování fontů atd. Navíc jsou komponenty Aspose Java založeny na základních třídách systému Java, které také v mnoha případech vyžadují nastavení oprávnění Full Trust.

{{% /alert %}} 

Poskytovatelé internetových služeb hostující více aplikací od různých společností většinou uplatňují úroveň zabezpečení Medium Trust:

- OleDbPermission není k dispozici. To znamená, že nemůžete použít spravovaný poskytovatel dat ADO.NET OLE DB k přístupu k databázím.
- EventLogPermission není k dispozici. To znamená, že nemůžete přistupovat k protokolu událostí Windows.
- ReflectionPermission není k dispozici. To znamená, že nemůžete používat reflexi.
- RegistryPermission není k dispozici. To znamená, že nemůžete přistupovat k registru.
- WebPermission je omezená. To znamená, že vaše aplikace může komunikovat pouze s adresou nebo rozsahem adres, které definujete v elementu <trust>.
- FileIOPermission je omezená. To znamená, že můžete přistupovat pouze k souborům ve virtuální hierarchii adresářů vaší aplikace.

{{% alert color="info" %}} 

Z důvodů uvedených výše nelze komponenty Aspose Java použít na serverech, které poskytují nastavení oprávnění jiná než Full Trust.

{{% /alert %}}