---
title: Requisitos do Sistema
type: docs
weight: 80
url: /pt/cpp/system-requirements/
keywords:
- requisitos do sistema
- sistema operacional
- instalação
- dependências
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Descubra os requisitos do sistema do Aspose.Slides para C++. Garanta suporte perfeito ao PowerPoint e OpenDocument no Windows, Linux e macOS."
---
## **Introdução**

Aspose.Slides não requer que o Microsoft PowerPoint esteja instalado porque Aspose.Slides é um mecanismo independente de criação, conversão, layout de página e renderização de documentos Microsoft PowerPoint.

## **Sistemas Operacionais Compatíveis**
Aspose.Slides para C++ é uma biblioteca nativa C++. Aspose.Slides para C++ oferece suporte aos seguintes sistemas operacionais e plataformas de 64 bits e 32 bits:

### **Windows**
- Microsoft Windows Server 2008 (x64, x86)
- Microsoft Windows Server 2012 (x64, x86)
- Microsoft Windows Server 2012 R2 (x64, x86)
- Microsoft Windows Server 2016 (x64, x86)
- Microsoft Windows Server 2019 (x64, x86)
- Microsoft Windows XP (x64, x86)
- Microsoft Windows 7 (x64, x86)
- Microsoft Windows 8, 8.1 (x64, x86)
- Microsoft Windows 10 (x64, x86)

### **Linux**
- Ubuntu 16.04 ou posterior.
- CentOS 8 ou posterior.
- Fedora 24 ou posterior.
- E outras distribuições Linux x86_64 com glibc 2.23 ou posterior.

### **macOS**
- macOS Monterey 12.1 ou posterior.

## **Ambientes de Desenvolvimento**
Você pode usar Aspose.Slides para C++ ao desenvolver aplicações para Windows, Linux ou macOS.

### **Windows**
- Microsoft Visual Studio 2017 ou posterior.
- CMake 3.18 ou posterior.

### **Linux**
- Clang 3.9 ou posterior.
- GCC 6.1 ou posterior.
- CMake 3.18 ou posterior.

### **macOS**
- Xcode 13.4 ou posterior.

## **Perguntas Frequentes**

**Preciso ter o Microsoft PowerPoint instalado para conversões e renderização?**

Não, o PowerPoint não é necessário; Aspose.Slides é um mecanismo independente para [criar](/slides/pt/cpp/create-presentation/), modificar, [converter](/slides/pt/cpp/convert-presentation/) e [renderizar](/slides/pt/cpp/convert-powerpoint-to-png/) apresentações.

**Quais fontes são necessárias para renderização correta?**

Na prática, as fontes usadas na apresentação ou [substitutos](/slides/pt/cpp/font-substitution/) adequados devem estar disponíveis. Para garantir renderização consistente em Linux/macOS, é recomendável instalar pacotes de fontes comuns.

**Por que uma fonte personalizada é renderizada como fonte de fallback ou texto ausente no Linux?**

Se o arquivo de fonte tiver entradas da tabela de nomes inconsistentes ou corrompidas, a pilha de correspondência de fontes do Linux (FreeType/fontconfig) pode selecionar um registro inválido, fazendo com que a fonte não seja resolvida. Usar uma versão da fonte com registros de tabela de nomes corrigidos ou instalar um substituto consistente resolve o problema.