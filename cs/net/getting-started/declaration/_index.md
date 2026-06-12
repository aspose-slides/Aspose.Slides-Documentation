---
title: Prohlášení
type: docs
weight: 110
url: /cs/net/declaration/
keywords:
- prohlášení
- komponenty
- Full Trust oprávnění
- nastavení registru
- systémové soubory
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Dozvíte se o požadavcích důvěryhodnosti, oprávněních a omezeních hostování Aspose.Slides pro .NET, abyste mohli bezpečně nasazovat aplikace, které zpracovávají soubory PPT, PPTX a ODP na serverech."
---
{{% alert color="primary" %}} 

Všechny komponenty Aspose .NET vyžadují sadu oprávnění Full Trust, protože někdy potřebují přistupovat k nastavením registru, systémovým souborům a souborům uloženým na jiných místech (mimo virtuální adresář) pro určité operace (například parsování fontů). Navíc jsou komponenty Aspose .NET založeny na základních třídách .NET systému, které v mnoha případech vyžadují sadu oprávnění Full Trust. 

{{% /alert %}} 

Poskytovatelé internetových služeb, kteří hostují více aplikací od různých firem, většinou vynucují úroveň zabezpečení Medium Trust. V případě .NET 2.0 tato úroveň zabezpečení uplatňuje následující omezení: 

- OleDbPermission není k dispozici. To znamená, že nemůžete použít řízený poskytovatel dat ADO.NET OLE DB pro přístup k databázím.
- EventLogPermission není k dispozici. To znamená, že nemáte přístup k protokolu událostí Windows.
- ReflectionPermission není k dispozici. To znamená, že nemůžete používat reflexi.
- RegistryPermission není k dispozici. To znamená, že nemáte přístup k registru.
- WebPermission je omezen. To znamená, že vaše aplikace může komunikovat pouze s adresou nebo rozsahem adres, které jste definovali v elementu <trust>.
- FileIOPermission je omezen. To znamená, že můžete přistupovat pouze k souborům v hierarchii virtuálního adresáře vaší aplikace.

{{% alert color="primary" %}} 

Z výše uvedených důvodů lze komponenty Aspose .NET používat pouze na serverech, které poskytují sadu oprávnění Full Trust. 

{{% /alert %}}