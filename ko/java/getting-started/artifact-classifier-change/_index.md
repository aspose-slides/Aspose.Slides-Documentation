---
title: 아티팩트 분류자 변경
type: docs
weight: 60
url: /ko/java/artifact-classifier-change/
keywords:
- 분류자 Aspose.Slides
- 아티팩트 분류자
- Aspose.Slides 사용
- Aspose.Slides 설치
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java는 이제 jdk16 대신 jdk8 분류자를 사용합니다. 이유와 종속성을 업데이트하는 방법을 알아보세요."
---
## **`jdk16`에서 `jdk8`(으)로 아티팩트 분류자 변경**
**26.10** 버전부터 게시된 아티팩트에서 사용하는 분류자를 **`jdk16`** (Java 6)에서 **`jdk8`** (Java 8)으로 변경했습니다.

### **변경 사항**

| | 이전 | 이후 |
|---|---|---|
| 분류자 | `jdk16` | `jdk8` |
| 최소 Java 버전 | Java 1.6 | Java 8 |

**이전:**
```
com.aspose:aspose-slides:26.10:jdk16
```

**이후:**
```
com.aspose:aspose-slides:26.10:jdk8
```

### **왜 이 변경을 했는가**

내부 검토 후, 더 이상 가치가 없고 유지 보수를 방해하는 오래된 Java 버전에 대한 지원을 **중단하기로** 결정했습니다. 모든 사용자를 위한 새로운 안전 기준으로 Java 8을 선택했습니다.

이에 따라 실제 최소 지원 버전을 반영하도록 분류자를 업데이트했습니다. 또한 Oracle의 현재 명명 규칙에 맞추어 제품을 공식적으로 **JDK 8**(레거시 `1.8` 형식이 아니라)이라고 부릅니다.

### **해야 할 일**

1. **분류자를** `jdk16`에서 `jdk8`로 업데이트하십시오.

   **Maven:**
   ```xml
   <dependency>
     <groupId>com.aspose</groupId>
     <artifactId>aspose-slides</artifactId>
     <version>26.10</version>
     <classifier>jdk8</classifier>
   </dependency>
   ```

   **Gradle:**
   ```groovy
   implementation 'com.aspose:aspose-slides:26.10:jdk8'
   ```

2. **런타임 환경이** Java 8 이상인지 확인하십시오.

3. **잠금 파일**이나 오래된 분류자를 고정하고 있는 종속성 캐시를 새로 고치십시오.

### **마이그레이션 참고: jdk16 및 jdk8**

**26.10** 버전부터, jdk16과 jdk8 두 분류자 모두 Java 8 호환 JAR를 제공할 것입니다(소스/타깃 호환성을 Java 8로 설정하여 빌드).

- `jdk16` → 이전 호환성(기존 통합)을 위해 계속 게시됩니다.
- `jdk8` → Java 8 환경을 위한 새로운 기본 분류자로 도입되었습니다.

⚠️ 참고: 이 이중 게시 단계는 2027년 3월 31일에 종료될 예정입니다. 해당 날짜 이후에는 jdk16 분류자가 폐기되고 jdk8만 지원됩니다.

### **호환성 참고**

- `jdk16` 분류자는 **2027년 3월 31일** 이후 **더 이상 게시되지 않습니다**.
- Java 1.6 지원이 아직 필요하다면, 마이그레이션이 가능할 때까지 이전 메이저 버전 라인을 유지하십시오.

### **도움이 필요하신가요?**

마이그레이션 중 문제가 발생하면, 추가 지원을 위해 [Aspose 지원](https://forum.aspose.com/)에 문의하십시오.