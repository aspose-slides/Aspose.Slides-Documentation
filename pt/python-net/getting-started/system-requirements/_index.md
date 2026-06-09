---
title: Requisitos do Sistema
type: docs
weight: 60
url: /pt/python-net/system-requirements/
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
- Python
- Aspose.Slides
description: "Descubra os requisitos de sistema do Aspose.Slides for Python via .NET. Garanta suporte perfeito a PowerPoint e OpenDocument no Windows, Linux e macOS."
---
## **Introdução**

Aspose.Slides for Python via .NET não requer nenhum produto de terceiros, como o Microsoft PowerPoint, instalado. Aspose.Slides é um mecanismo para criar, modificar, converter e renderizar documentos em vários formatos, incluindo os formatos de apresentação do Microsoft PowerPoint.

## **Sistemas Operacionais Suportados**

Aspose.Slides for Python oferece suporte a Windows (32 bits e 64 bits), macOS e Linux 64 bits em sistemas com Python 3.5 ou posterior instalada.

<table>  
    <tr>
        <td style="font-weight: bold; width:400px">Sistema Operacional</td>
        <td style="font-weight: bold; width:400px">Versões</td>
    </tr>
    <tr>
        <td>Microsoft Windows</td>
        <td>
            <ul>
                <li>Windows 2003 Server</li>
                <li>Windows 2008 Server</li>
                <li>Windows 2012 Server</li>
                <li>Windows 2012 R2 Server</li>
                <li>Windows 2016 Server</li>
                <li>Windows 2019 Server</li>
                <li>Windows XP</li>
                <li>Windows Vista</li>
                <li>Windows 7</li>
                <li>Windows 8, 8.1</li>
                <li>Windows 10</li>
                <li>Windows 11</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>Linux</td>
        <td>
            <ul>
                <li>Ubuntu</li>
                <li>OpenSUSE</li>
                <li>CentOS</li>
                <li>e outros</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>macOS</td>
        <td>
            <ul>
                <li>12 "Monterey"</li>
            </ul>
        </td>
    </tr>
</table>

## **Requisitos de Sistema para Plataformas Linux e macOS Alvo**

- Bibliotecas de tempo de execução GCC 6 (ou posterior).
- [libgdiplus](https://github.com/mono/libgdiplus), uma implementação de código aberto da API GDI+.
- Dependências do .NET Core Runtime. Instalar o .NET Core Runtime em si NÃO é necessário.
- Para Python 3.5–3.7: a compilação `pymalloc` do Python é exigida. A opção de compilação `--with-pymalloc` está habilitada por padrão. Normalmente, a compilação `pymalloc` do Python apresenta o sufixo `m` no nome do arquivo.
- A biblioteca compartilhada `libpython`. A opção de compilação `--enable-shared` do Python está desabilitada por padrão, e algumas distribuições Python não incluem a biblioteca `libpython`. Em algumas plataformas Linux, você pode instalar a biblioteca `libpython` usando o gerenciador de pacotes (por exemplo, `sudo apt-get install libpython3.7`). Um problema comum é que a biblioteca `libpython` está instalada em um local não padrão para bibliotecas compartilhadas. Você pode resolver isso usando opções de compilação do Python para definir caminhos alternativos de bibliotecas ao compilar o Python, ou criando um link simbólico para o arquivo da biblioteca `libpython` na localização padrão de bibliotecas compartilhadas do sistema. Normalmente, o nome do arquivo da biblioteca compartilhada `libpython` é `libpythonX.Ym.so.1.0` para Python 3.5–3.7 ou `libpythonX.Y.so.1.0` para Python 3.8 ou posterior (por exemplo, `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

## **Perguntas Frequentes**

**Preciso ter o Microsoft PowerPoint instalado para conversões e renderização?**

Não, o PowerPoint não é necessário; o Aspose.Slides é um mecanismo autônomo para [criar](/slides/pt/python-net/create-presentation/), modificar, [converter](/slides/pt/python-net/convert-presentation/) e [renderizar](/slides/pt/python-net/convert-powerpoint-to-png/) apresentações.

**É necessária uma versão específica do .NET (Core/5+/6+) na máquina?**

Instalar o .NET Runtime em si não é necessário, mas suas dependências devem estar presentes no Linux/macOS. Isso significa que o sistema deve conter os pacotes normalmente instalados como dependências do .NET, sem instalar o runtime completo.

**Quais fontes são necessárias para renderização correta?**

Na prática, as fontes usadas na apresentação ou substitutos adequados [/slides/pt/python-net/font-substitution/] devem estar disponíveis. Para garantir renderização consistente em Linux/macOS, recomenda‑se instalar pacotes de fontes comuns.

**Por que uma fonte personalizada é renderizada como substituta ou texto ausente no Linux?**

Se o arquivo de fonte possuir entradas de tabela de nomes inconsistentes ou corrompidas, a pilha de correspondência de fontes do Linux (FreeType/fontconfig) pode selecionar um registro inválido, causando a fonte não resolvida. Utilizar uma versão da fonte com registros de tabela de nomes corrigidos ou instalar uma substituta consistente resolve o problema.