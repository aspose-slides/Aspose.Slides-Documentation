---
title: Declaração
type: docs
weight: 110
url: /pt/net/declaration/
keywords:
- declaração
- componentes
- permissão Full Trust
- configurações de registro
- arquivos do sistema
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda sobre os requisitos de confiança, permissões e limitações de hospedagem do Aspose.Slides para .NET, para que você possa implantar aplicativos que processam PPT, PPTX e ODP em servidores com segurança."
---
{{% alert color="primary" %}} 

Todos os componentes Aspose .NET requerem o conjunto de permissões Full Trust porque às vezes precisam acessar configurações de registro, arquivos do sistema e arquivos armazenados em outros locais (além do diretório virtual) para certas operações (por exemplo, análise de fontes). Além disso, os Componentes Aspose .NET são baseados nas classes principais do sistema .NET, que em muitos casos exigem o conjunto de permissões Full Trust. 

{{% /alert %}} 

Os provedores de serviços de Internet, que hospedam múltiplas aplicações de diferentes empresas, geralmente impõem o nível de segurança Medium Trust. Em um caso .NET 2.0, esse nível de segurança aplica as seguintes restrições: 

- OleDbPermission não está disponível. Isso significa que você não pode usar o provedor de dados OLE DB gerenciado do ADO.NET para acessar bancos de dados.
- EventLogPermission não está disponível. Isso significa que você não pode acessar o log de eventos do Windows.
- ReflectionPermission não está disponível. Isso significa que você não pode usar reflexão.
- RegistryPermission não está disponível. Isso significa que você não pode acessar o registro.
- WebPermission é restrito. Isso significa que sua aplicação só pode se comunicar com um endereço ou o intervalo de endereços que você definiu no elemento <trust>.
- FileIOPermission é restrito. Isso significa que você só pode acessar arquivos na hierarquia do diretório virtual da sua aplicação.

{{% alert color="primary" %}} 

Devido aos motivos acima, os componentes Aspose .NET só podem ser usados em servidores que concedem o conjunto de permissões Full Trust. 

{{% /alert %}}