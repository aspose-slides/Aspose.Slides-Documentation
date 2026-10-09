---
title: 선언
type: docs
weight: 60
url: /ko/java/artifact-classifier-change/
keywords:
- 분류자 Aspose.Slides
- 아티팩트 분류자
- Aspose.Slides 사용
- Aspose.Slides 설치
- 윈도우
- 리눅스
- macOS
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java가 이제 jdk16 대신 jdk8 분류자를 사용합니다. 왜 변경되었는지와 종속성을 업데이트하는 방법을 확인하세요."
---
## 아티팩트 분류자 변경: `jdk16`에서 `jdk8`(으)로

버전 **26.10**부터 게시된 아티팩트에서 사용되는 분류자를 **`jdk16`**(Java 6)에서 **`jdk8`**(Java 8)으로 변경했습니다.

### 변경 내용

|  | 이전 | 이후 |
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

### 이 변경을 한 이유

내부 검토 후, 더 이상 가치가 없고 유지 관리에 방해가 되는 이전 Java 버전에 대한 지원을 **중단하기로** 결정했습니다. 모든 사용자를 위한 새로운 안전 기준으로 Java 8을 선택했습니다.

이에 따라 분류자를 실제 최소 지원 버전을 반영하도록 업데이트했습니다. 또한 제품을 공식적으로 **JDK 8**이라고 부르는 현재 Oracle 명명 규칙에 맞추었습니다(`1.8` 형식 대신).

### 필요한 조치

1. **분류자를** `jdk16`에서 `jdk8`(으)로 의존성 선언에서 **업데이트**합니다.

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

2. **런타임 환경이** Java 8 이상인지 **확인**합니다.

3. 이전 분류자를 고정하는 모든 lock 파일 또는 의존성 캐시를 **새로 고칩니다**.

### 마이그레이션 참고: jdk16 및 jdk8

버전 26.10부터, jdk16과 jdk8 분류자는 모두 Java 8 호환 JAR을 제공합니다(소스/타깃 호환성을 Java 8로 설정하여 빌드).

- `jdk16` → 이전 호환성(기존 통합)을 위해 계속 게시됩니다.
- `jdk8` → Java 8 환경을 위한 새로운 기본 분류자로 도입됩니다.

⚠️ 참고: 이 이중 게시 단계는 2027년 3월 31일에 종료될 예정입니다. 해당 날짜 이후에는 jdk16 분류자가 폐기되고 jdk8만 지원됩니다.

### 호환성 주의 사항

- `jdk16` 분류자는 **2027년 3월 31일** 이후 **더 이상 게시되지 않습니다**.
- Java 1.6 지원이 여전히 필요하다면 마이그레이션이 가능할 때까지 이전 주요 버전 라인을 유지하십시오.

### 도움이 필요하신가요?

마이그레이션 중 문제가 발생하면 [Aspose 지원](https://forum.aspose.com/)에 문의하시기 바랍니다.