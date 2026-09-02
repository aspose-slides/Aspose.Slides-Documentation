---
title: Migrar para o Novo Motor Python-para-.NET na Versão 26.8
linktitle: Migrar para o Novo Motor
type: docs
weight: 290
url: /pt/python-net/migrate-to-new-engine/
keywords:
- novo motor
- migração
- aspose.pydrawing
- primitivos de desenho
- Point
- Color
- Rectangle
- ImportError
- AttributeError
- Python
- Aspose.Slides
description: "Mova seu código Python para o novo motor Aspose.Slides na versão 26.8: realoque os primitivos de desenho para aspose.slides e corrija as importações automaticamente."
---
## **Introdução**

A versão 26.8 substitui o mecanismo que conecta Python ao .NET. Os primitivos de desenho foram movidos para o módulo `aspose.slides`.

Vá direto para [Tenho um Erro](#i-have-an-error) se você tiver problemas após a atualização.

### **Primitivos de Desenho Movidos para aspose.slides**

Sete tipos foram movidos. Eles mantêm seus nomes, argumentos e comportamento:

|Tipo|Antes de 26.8|26.8 e Posteriores|
| :- | :- | :- |
|Point|`aspose.pydrawing.Point`|[aspose.slides.Point](https://reference.aspose.com/slides/pt/python-net/aspose.slides/point/)|
|PointF|`aspose.pydrawing.PointF`|[aspose.slides.PointF](https://reference.aspose.com/slides/pt/python-net/aspose.slides/pointf/)|
|Size|`aspose.pydrawing.Size`|[aspose.slides.Size](https://reference.aspose.com/slides/pt/python-net/aspose.slides/size/)|
|SizeF|`aspose.pydrawing.SizeF`|[aspose.slides.SizeF](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sizef/)|
|Rectangle|`aspose.pydrawing.Rectangle`|[aspose.slides.Rectangle](https://reference.aspose.com/slides/pt/python-net/aspose.slides/rectangle/)|
|RectangleF|`aspose.pydrawing.RectangleF`|[aspose.slides.RectangleF](https://reference.aspose.com/slides/pt/python-net/aspose.slides/rectanglef/)|
|Color|`aspose.pydrawing.Color`|[aspose.slides.Color](https://reference.aspose.com/slides/pt/python-net/aspose.slides/color/)|

Esses sete tipos eram todo o conteúdo restante de `aspose.pydrawing`. Depois de redirecioná‑los, nada no seu código precisa referenciar `aspose.pydrawing` e todas as importações dele podem ser removidas. Isso também facilita a verificação – veja [Verificar a Migração](#verify-the-migration).

**Código Legado:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.red

    with slide.get_image(drawing.Size(1920, 1080)) as slide_image:
        slide_image.save("slide1.jpeg", slides.ImageFormat.JPEG)
```

**Versão 26.8:**

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.red

    with slide.get_image(slides.Size(1920, 1080)) as slide_image:
        slide_image.save("slide1.jpeg", slides.ImageFormat.JPEG)
```

A forma de importação `from` muda da mesma maneira:

```python
# Código Legado
from aspose.pydrawing import Color, Point

# Versão 26.8
from aspose.slides import Color, Point
```

## **Corrigir um Erro de Importação**

Encontre seu rastreamento de pilha na primeira coluna.

|Erro|Causa|Correção|
| :- | :- | :- |
|`AttributeError: module 'aspose.pydrawing' has no attribute 'Color'` (or `Point`, `Rectangle`, and so on)|O pacote está na versão 26.8, mas o código ainda aponta para o módulo antigo|[Atualize seu código](#update-your-code)|
|`ImportError: cannot import name 'Color' from 'aspose.pydrawing'`|A mesma causa, forma de importação `from`|[Atualize seu código](#update-your-code)|
|`ModuleNotFoundError: No module named 'aspose.pydrawing'`|O módulo e todos os seus sete tipos foram movidos para `aspose.slides`|[Atualize seu código](#update-your-code), então exclua a importação `aspose.pydrawing`|
|`ImportError: cannot import name 'Color' from 'aspose.slides'`|O código foi migrado, mas o pacote instalado está na versão 26.7 ou anterior|`pip install --upgrade aspose.slides`|
|`TypeError` on a color, point, or size argument|Um valor criado a partir de `aspose.pydrawing` foi passado para a nova API|Crie o valor também a partir de `aspose.slides`|

## **Atualize Seu Código**

Como `aspose.pydrawing` não tem conteúdo além dos sete tipos movidos, a migração consiste em renomear o módulo. Todas as formas de importação são cobertas por esse único rename, incluindo aliases:

```python
# Código legado
import aspose.pydrawing as drawing
color = drawing.Color.red

# Versão 26.8 - o alias continua funcionando
import aspose.slides as drawing
color = drawing.Color.red
```

Isso é válido em qualquer escopo, inclusive dentro do corpo de uma função, porque o alias permanece vinculado exatamente onde estava antes. A única desvantagem é um nome enganoso, então considere tornar a intenção explícita:

```python
import aspose.slides as slides
color = slides.Color.red
```

Escolha a abordagem que corresponde ao tamanho da sua base de código.

### **Substituir Manualmente**

Para alguns arquivos, procure por `aspose.pydrawing` e substitua por `aspose.slides`, então remova qualquer importação que não seja mais necessária.

### **Substituir com um Comando Shell**

Esta é uma substituição de texto simples, portanto também afeta ocorrências dentro de strings e comentários. Ambos os comandos escrevem uma cópia `.bak` de cada arquivo que alteram.

**Linux:**

```bash
grep -rlZ --include='*.py' 'aspose\.pydrawing' . \
  | xargs -0 -r sed -i.bak 's/aspose\.pydrawing/aspose.slides/g'
```

No macOS, use `sed -i ''` em vez de `sed -i.bak`, ou instale o GNU sed como `gsed`.

**Windows PowerShell:**

```
Get-ChildItem -Recurse -Filter *.py | ForEach-Object {
  $t = Get-Content $_ -Raw
  $new = $t -replace 'aspose\.pydrawing', 'aspose.slides'
  if ($new -ne $t) {
    Copy-Item $_.FullName "$($_.FullName).bak"
    Set-Content $_.FullName $new -NoNewline
    $_.FullName
  }
}
```

Para reverter no Linux ou macOS:

```bash
find . -name '*.py.bak' -exec sh -c 'mv "$1" "${1%.bak}"' _ {} \;
```

Para reverter no Windows:

```
Get-ChildItem -Recurse -Filter *.py.bak | ForEach-Object {
  Move-Item $_.FullName ($_.FullName -replace '\.bak$', '') -Force
}
```

### **Substituir com um Script Python**

O mesmo rename, portátil para Linux, macOS e Windows. O script recebe o caminho como argumento e pré‑visualiza as alterações a menos que `--write` seja passado. Adicione `--backup` para manter uma cópia `.bak` de cada arquivo alterado. Salve‑o com qualquer nome – a mensagem de uso detecta o nome em tempo de execução.

```python
"""Rename aspose.pydrawing to aspose.slides. Plain text replacement.

    python <this script> src/                     # preview
    python <this script> src/ --write             # apply
    python <this script> src/ --write --backup    # apply, keeping .bak copies
"""

import sys
from pathlib import Path

W = "--write" in sys.argv
B = "--backup" in sys.argv
ROOT = next((a for a in sys.argv[1:] if not a.startswith("-")), None)

if ROOT is None:
    sys.exit(f"usage: python {Path(sys.argv[0]).name} <path> [--write] [--backup]")

root = Path(ROOT)
if not root.exists():
    sys.exit(f"no such path: {root}")

files = [root] if root.is_file() else root.rglob("*.py")
changed = 0

for p in files:
    if {".venv", "venv", "__pycache__", ".git"} & set(p.parts):
        continue
    s = p.read_text(encoding="utf-8")
    n = s.replace("aspose.pydrawing", "aspose.slides")
    if n == s:
        continue
    changed += 1
    print(("wrote " if W else "would change ") + str(p))
    if W:
        if B:
            p.with_suffix(p.suffix + ".bak").write_text(s, encoding="utf-8")
        p.write_text(n, encoding="utf-8")

print(f"{changed} file(s) {'changed' if W else 'to change'}"
      + ("" if W or not changed else "; rerun with --write to apply"))
```

Uma execução típica se parece com isto:

```console
$ python migrate.py src/
would change src/render.py
would change src/export/slides.py
2 file(s) to change; rerun with --write to apply

$ python migrate.py src/ --write --backup
wrote src/render.py
wrote src/export/slides.py
2 file(s) changed
```

O caminho pode ser um diretório, que é percorrido recursivamente, ou um único arquivo `.py`.

### **Substituir com um Script Baseado em AST**

Recomendado para bases de código maiores. Este script realiza o mesmo rename, mas analisa cada arquivo primeiro, de modo que nunca altera ocorrências dentro de strings, comentários ou docstrings.

Como ele renomeia o módulo in‑place e deixa os aliases intactos, todas as formas de importação são tratadas sem casos especiais: `import aspose.pydrawing`, `import aspose.pydrawing as X`, `from aspose.pydrawing import Color`, `from aspose.pydrawing import Color as C`, importações multilinha entre parênteses, importações dentro de funções e o módulo passado como valor. Ele aceita as mesmas flags `--write` e `--backup`.

```python
"""Rename aspose.pydrawing to aspose.slides, skipping strings and comments.

    python <this script> src/                     # preview
    python <this script> src/ --write             # apply
    python <this script> src/ --write --backup    # apply, keeping .bak copies
"""

import ast, sys
from pathlib import Path

MOD, DST = "aspose.pydrawing", "aspose.slides"
W = "--write" in sys.argv
B = "--backup" in sys.argv
ROOT = next((a for a in sys.argv[1:] if not a.startswith("-")), None)

if ROOT is None:
    sys.exit(f"usage: python {Path(sys.argv[0]).name} <path> [--write] [--backup]")

root = Path(ROOT)
if not root.exists():
    sys.exit(f"no such path: {root}")

files = [root] if root.is_file() else root.rglob("*.py")
changed = 0


def chain(n):
    p = []
    while isinstance(n, ast.Attribute):
        p.append(n.attr)
        n = n.value
    return ".".join(reversed(p + [n.id])) if isinstance(n, ast.Name) else None


def fix(src):
    tree = ast.parse(src)
    off, o = [], 0
    for l in src.encode().splitlines(keepends=True):
        off.append(o)
        o += len(l)
    off.append(o)
    edits = []

    for n in ast.walk(tree):
        # import aspose.pydrawing [como X]  /  de aspose.pydrawing import ...
        # O nome do módulo é renomeado no local, portanto qualquer alias permanece vinculado como antes.
        if (isinstance(n, ast.Import) and any(a.name == MOD for a in n.names)) or \
           (isinstance(n, ast.ImportFrom) and n.module == MOD):
            s, e = off[n.lineno - 1], off[n.end_lineno - 1] + n.end_col_offset
            edits.append((s, e, src.encode()[s:e].decode().replace(MOD, DST)))
        # Qualquer expressão que referencie o módulo, incluindo `fn(aspose.pydrawing)` sem prefixo.
        elif isinstance(n, ast.Attribute) and chain(n) == MOD:
            edits.append((off[n.lineno - 1] + n.col_offset,
                          off[n.end_lineno - 1] + n.end_col_offset, DST))

    b = src.encode()
    for s, e, r in sorted(edits, reverse=True):  # back to front keeps offsets valid
        b = b[:s] + r.encode() + b[e:]
    return b.decode()


for p in files:
    if {".venv", "venv", "__pycache__", ".git"} & set(p.parts):
        continue
    s = p.read_text(encoding="utf-8")
    try:
        n = fix(s)
    except SyntaxError as e:
        print(f"skipped {p}: {e}")
        continue
    if n != s:
        print(("wrote " if W else "would change ") + str(p))
        if W:
            if B:
                p.with_suffix(p.suffix + ".bak").write_text(s, encoding="utf-8")
            p.write_text(n, encoding="utf-8")
```

Ambos os scripts são idempotentes: executá‑los novamente em código migrado não altera nada.

## **Verificar a Migração**

Uma busca de texto mostra se algo ainda resta:

```bash
grep -rn 'aspose\.pydrawing' --include='*.py' --exclude-dir=.venv .
```

Isso é rápido, mas também corresponde dentro de strings e comentários, portanto código limpo pode ainda gerar ocorrências. Para uma resposta definitiva, use a verificação abaixo. Ela reporta apenas referências reais ao código e sai com status diferente de zero se houverem restantes, o que a torna utilizável como porta de compilação.

```python
import ast, sys
from pathlib import Path

MOD = "aspose.pydrawing"
ROOT = next((a for a in sys.argv[1:] if not a.startswith("-")), ".")


def chain(n):
    p = []
    while isinstance(n, ast.Attribute):
        p.append(n.attr)
        n = n.value
    return ".".join(reversed(p + [n.id])) if isinstance(n, ast.Name) else None


def scan(tree):
    for n in ast.walk(tree):
        if isinstance(n, ast.Import) and any(a.name == MOD for a in n.names):
            yield n.lineno, f"import {MOD}"
        elif isinstance(n, ast.ImportFrom) and n.module == MOD:
            names = ", ".join(a.name for a in n.names)
            yield n.lineno, f"from {MOD} import {names}"
        elif isinstance(n, ast.Attribute) and chain(n) == MOD:
            yield n.lineno, f"reference to {MOD}"


hits = 0
for p in sorted(Path(ROOT).rglob("*.py")):
    if {".venv", "venv", "__pycache__", ".git"} & set(p.parts):
        continue
    try:
        tree = ast.parse(p.read_text(encoding="utf-8"))
    except SyntaxError as e:
        print(f"skipped {p}: {e}")
        continue
    for lineno, what in sorted(scan(tree)):
        print(f"{p}:{lineno}: {what}")
        hits += 1

print("migration complete" if not hits else f"{hits} reference(s) left")
sys.exit(1 if hits else 0)
```

Execute-a antes e depois da migração:

```console
$ python verify.py src/
src/render.py:4: from aspose.pydrawing import Color, Point
src/render.py:11: import aspose.pydrawing
src/render.py:12: reference to aspose.pydrawing
3 reference(s) left

$ python migrate.py src/ --write
wrote src/render.py

$ python verify.py src/
migration complete
```

Finalmente, execute um teste rápido que exercita os tipos movidos:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.red

    presentation.save("smoke.pptx", slides.export.SaveFormat.PPTX)
    print("OK")
```

## **Ordem Recomendada de Migração**

1. **Salve uma linha de base.** Execute seus testes na versão atual e mantenha renders de referência. Isso permite separar erros de migração de diferenças de renderização posteriormente.
2. **Pré‑visualize a migração.** Execute um dos scripts sem `--write` e revise a lista de arquivos que seriam alterados.
3. **Aplique e verifique.** Execute com `--write --backup`, depois o script de verificação e o teste rápido.
4. **Compare renders com tolerância.** A mudança para a build .NET 6 pode gerar pequenas diferenças em texto e efeitos. Use uma comparação baseada em limiar ao invés de verificação byte‑a‑byte.
5. **Remova os backups.** Quando o resultado estiver confirmado, delete os arquivos `.bak`: `find . -name '*.py.bak' -delete` no Linux e macOS, ou `Get-ChildItem -Recurse -Filter *.py.bak | Remove-Item` no Windows.

## **Suporte a Ambas as Versões em uma Base de Código**

Se precisar rodar contra 26.7 e 26.8 a partir da mesma fonte:

```python
try:
    from aspose.slides import Color, Point, Rectangle      # 26.8 e posterior
except ImportError:
    from aspose.pydrawing import Color, Point, Rectangle   # 26.7 e anterior
```

## **O que Não Mudou**

- Nomes, argumentos e comportamento dos primitivos movidos.
- O restante da superfície da API `aspose.slides`.
- Licenciamento e como o arquivo de licença é aplicado.
- Formatos de arquivo e o comportamento de salvar e carregar.
- Requisitos de sistema no Windows e macOS.
- A ausência de uma instalação .NET separada – o runtime ainda está incluído.